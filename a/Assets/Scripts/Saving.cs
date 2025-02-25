using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;


public static class Saving // this class had to be renamed cuz of a bug
{
    private static string path; // the path
    public static List<GameObject> spawnedObjects = new(); // list of all spawned gameObjects

    public static void RegisterObject(GameObject go) // method for registering gameObjects
    {
        if (!spawnedObjects.Contains(go))
        {
            spawnedObjects.Add(go);
        }
    }

    public static void UnregisterObject(GameObject go) // method for unregistering gameObjects
    {
        spawnedObjects.Remove(go);
        Saveable savebale = go.GetComponent<Saveable>();

        // also delete it 
        path = Application.persistentDataPath + "/" + savebale.prefabName+savebale.id + ".dat";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    
    public static bool SaveExists(GameObject go) // method for checking for a specific savefile
    {
        Saveable savebale = go.GetComponent<Saveable>();
        path = Application.persistentDataPath + "/" + savebale.prefabName+savebale.id + ".dat";
        return File.Exists(path); // return as a bool
    }
    
    public static void SaveGO(GameObject go)
    {
        
        Saveable saveable = go.GetComponent<Saveable>(); // get the saveable component of the go
        if (saveable == null)
        {
            Debug.Log("Saveable component missing on: " + go.name); // log it if its missing
        }
        // get the stats, tile and the position
        Stats stats = go.GetComponent<Stats>();
        Tile tile = go.GetComponent<Tile>();
        float[] position = { go.transform.position.x, go.transform.position.y, go.transform.position.z };
        
        
        // set the prefab name
        string prefabName = (saveable != null) ? saveable.prefabName+saveable.id : null;
        if (string.IsNullOrEmpty(prefabName))
        {
            prefabName = go.name;
        }

        // get all of the variables
        int woodOnTree = (tile != null && tile.isTree) ? tile.woodOnTree : 0;
        int woodInStock = stats != null ? stats.woodInStock : 0;
        int foodInStock = stats != null ? stats.foodInStock : 0;
        int humansInStock = stats != null ? stats.humansInStock : 0;
        int totalhumansInStock = stats != null ? stats.totalhumansInStock : 0;
        bool isTree = tile != null && tile.isTree;
        // then, create new playerData with all  the previous variables
        PlayerData data = new PlayerData(prefabName, woodOnTree, woodInStock, foodInStock, humansInStock, totalhumansInStock, isTree, position);
        // create a binary formatter and save the go with the prefab name
        BinaryFormatter bf = new BinaryFormatter();
        path = Application.persistentDataPath + "/" + prefabName + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, data);
        stream.Close(); // close the stream to avoid errors
    }

    
    
    
    public static void Load(GameObject go)
    {
        // get the saveable from the go (will only work on gameObjects already in the scene)
        Saveable saveable = go.GetComponent<Saveable>();
        if (saveable == null)
        {
            Debug.Log("Saveable component missing on: " + go.name);
        }
        
        string prefabName = (saveable != null && !string.IsNullOrEmpty(saveable.prefabName)) // set the prefab name
            ? saveable.prefabName+saveable.id
            : go.name;
        
        path = Application.persistentDataPath + "/" + prefabName + ".dat"; // get the right path
        Debug.Log("Final Path: " + path);
        
        
        if (File.Exists(path))
        {
            // open a binary formatter the deserialise from the path
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            if (data != null)
            {
                string fixedObjectname = Regex.Replace(data.name, @"\d", ""); // get the object name without the id (numbers)
                GameObject existingObject = GameObject.Find(fixedObjectname); // find by the fixed object name

                if (existingObject == null) // if it doesn't exist instantiate it
                {
                    GameObject prefab = Resources.Load<GameObject>(data.name);
                    if (prefab != null)
                    {
                        // create it with the required data
                        existingObject = GameObject.Instantiate(prefab, new Vector3(data.position[0], data.position[1], data.position[2]), Quaternion.identity);
                        existingObject.name = data.name+saveable.id; // set its name right
                    }
                    else
                    {
                        Debug.LogError("Prefab not found in Resources: " + data.name); // for debugging
                        return;
                    }
                }
                else // if it exists update its properties
                {
                    existingObject.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
                }

                // restore the stats, if the go has a stats component
                Stats stats = existingObject.GetComponent<Stats>();
                if (stats != null)
                {
                    stats.woodInStock = data.woodInStock;
                    stats.foodInStock = data.foodInStock;
                    stats.humansInStock = data.humansInStock;
                    stats.totalhumansInStock = data.totalhumansInStock;
                }

                // restore the tile, if the gameObject has a tile component, also this is redundant idk why im keeping it here
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
    
    public static PlayerData LoadData(string objectName) // very sigma helper method
    {
        string path = Application.persistentDataPath + "/" + objectName + ".dat";
    
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();
            return data; // return the data
        }

        return null;
    }
}