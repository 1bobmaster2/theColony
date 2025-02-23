using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class CreatingLoadingSaves : MonoBehaviour
{
    public GameObject[] allGO;
    public Stats statsitself;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        statsitself.humansInStock++;
        
    }


    public void SaveGame()
    {
        allGO = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allGO)
        {
            Saving.SaveGO(go);
            Debug.Log(go.name + " saved");
        }
    }

    public void LoadGame()
    {
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.dat");

        foreach (string file in files)
        {
            string objectName = System.IO.Path.GetFileNameWithoutExtension(file).Replace(".dat", "");
            Debug.LogWarning("current object name is equal to: " + objectName);
            string fixedObjectname = Regex.Replace(objectName, @"\d", "");
            Debug.LogWarning("current object name is equal to: " + fixedObjectname);
            GameObject existingObject = GameObject.Find(fixedObjectname);

            

            if (existingObject == null) // If the object doesn't exist, instantiate it
            {
                string theThingToFind = Regex.Replace(objectName, @"\d", "");
                GameObject prefab = Resources.Load<GameObject>(theThingToFind);
                Debug.LogError($"ok so the GameObject prefab is {prefab}");
    
                if (prefab != null)
                {
                    // Load the saved position BEFORE instantiating
                    PlayerData data = Saving.LoadData(objectName); // New method to load data
                    Vector3 savedPosition = (data != null) ? 
                        new Vector3(data.position[0], data.position[1], data.position[2]) : 
                        Vector3.zero; // Default to (0,0,0) if no data found

                    existingObject = Instantiate(prefab, savedPosition, Quaternion.identity);
                    existingObject.name = objectName;
                    Tile tile = existingObject.GetComponent<Tile>();
                    if (tile != null)
                    {
                        tile.isTree = data.isTree;
                        tile.woodOnTree = data.woodOnTree;
                    }
                }
                else
                {
                    Debug.LogError("Prefab not found in Resources: " + theThingToFind);
                    continue;
                }
            }

            Saving.Load(existingObject);
            Debug.Log(existingObject.name + " loaded");
        }
    }
}


