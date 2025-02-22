using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;


public static class Saving // this class had to be renamed cuz of a bug
{
    private static string path;
    public static List<GameObject> spawnedObjects = new();

    public static void RegisterObject(GameObject go)
    {
        if (!spawnedObjects.Contains(go))
        {
            spawnedObjects.Add(go);
        }
    }

    public static void UnregisterObject(GameObject go)
    {
        spawnedObjects.Remove(go);
        Saveable savebale = go.GetComponent<Saveable>();

        // Delete the save file to prevent reloading
        path = Application.persistentDataPath + "/" + savebale.prefabName+savebale.id + ".dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    
    public static bool SaveExists(GameObject go)
    {
        Saveable savebale = go.GetComponent<Saveable>();
        path = Application.persistentDataPath + "/" + savebale.prefabName+savebale.id + ".dat";
        return File.Exists(path);
    }
    
    public static void SaveGO(GameObject go)
    {
        
        Saveable saveable = go.GetComponent<Saveable>();
        if (saveable == null)
        {
            Debug.Log("Saveable component missing on: " + go.name);
        }

        Stats stats = go.GetComponent<Stats>();
        Tile tile = go.GetComponent<Tile>();
        float[] position = new float[] { go.transform.position.x, go.transform.position.y, go.transform.position.z };
        
        
        
        string prefabName = (saveable != null) ? saveable.prefabName+saveable.id : null;
        if (string.IsNullOrEmpty(prefabName))
        {
            prefabName = go.name;
        }

        
        int woodOnTree = (tile != null && tile.isTree) ? tile.woodOnTree : 0;
        int woodInStock = stats != null ? stats.woodInStock : 0;
        int foodInStock = stats != null ? stats.foodInStock : 0;
        int humansInStock = stats != null ? stats.humansInStock : 0;
        int totalhumansInStock = stats != null ? stats.totalhumansInStock : 0;
        bool isTree = tile != null && tile.isTree;

        PlayerData data = new PlayerData(prefabName, woodOnTree, woodInStock, foodInStock, humansInStock, totalhumansInStock, isTree, position);

        BinaryFormatter bf = new BinaryFormatter();
        path = Application.persistentDataPath + "/" + prefabName + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, data);
        stream.Close();
    }

    
    
    
    public static void Load(GameObject go)
    {
        Saveable saveable = go.GetComponent<Saveable>();
        if (saveable == null)
        {
            Debug.Log("Saveable component missing on: " + go.name);
        }
        
        string prefabName = (saveable != null && !string.IsNullOrEmpty(saveable.prefabName))
            ? saveable.prefabName+saveable.id
            : go.name;
        
        path = Application.persistentDataPath + "/" + prefabName + ".dat";
        Debug.Log("Final Path: " + path);
        
        
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            if (data != null)
            {
                
                GameObject existingObject = GameObject.Find(data.name);

                if (existingObject == null) // Object doesn't exist, instantiate it
                {
                    GameObject prefab = Resources.Load<GameObject>(data.name);
                    if (prefab != null)
                    {
                        existingObject = GameObject.Instantiate(prefab, new Vector3(data.position[0], data.position[1], data.position[2]), Quaternion.identity);
                        existingObject.name = data.name+saveable.id.ToString(); // Ensure correct naming
                    }
                    else
                    {
                        Debug.LogError("Prefab not found in Resources: " + data.name);
                        return;
                    }
                }
                else // Object exists, just update its properties
                {
                    existingObject.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
                }

                // Restore Stats component
                Stats stats = existingObject.GetComponent<Stats>();
                if (stats != null)
                {
                    stats.woodInStock = data.woodInStock;
                    stats.foodInStock = data.foodInStock;
                    stats.humansInStock = data.humansInStock;
                    stats.totalhumansInStock = data.totalhumansInStock;
                }

                // Restore Tile component
                Tile tile = existingObject.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.isTree = data.isTree;
                    tile.woodOnTree = data.woodOnTree;
                }
            }
        }
        else
        {
            Debug.LogError("No save file found for: " + saveable.prefabName);
        }
    }

}