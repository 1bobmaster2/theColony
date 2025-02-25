using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class CreatingLoadingSaves : MonoBehaviour
{
    public GameObject[] allGO; // array of every gameObject in the scene
    public Stats statsitself; // reference to the stats
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame(); // load the game on start
    }

    // Update is called once per frame
    void Update()
    {
        statsitself.humansInStock++; // increase humans every frame for debugging purposes
        
    }


    public void SaveGame()
    {
        allGO = FindObjectsOfType<GameObject>(); // get every go in the scene
        foreach (GameObject go in allGO)
        {
            Saving.SaveGO(go); // save the go in the array
            Debug.Log(go.name + " saved");
        }
    }

    public void LoadGame()
    {
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.dat"); // get all the files

        foreach (string file in files)
        {
            string objectName = System.IO.Path.GetFileNameWithoutExtension(file).Replace(".dat", ""); // get the object
            Debug.LogWarning("current object name is equal to: " + objectName);
            string fixedObjectname = Regex.Replace(objectName, @"\d", ""); // get the object name without the id
            Debug.LogWarning("current object name is equal to: " + fixedObjectname);
            GameObject existingObject = GameObject.Find(fixedObjectname); // check if the object (without id) already exists in the scene
            
            if (existingObject == null) // if it doesnt instantiate it
            {
                string theThingToFind = Regex.Replace(objectName, @"\d", ""); // get the object name without the id
                GameObject prefab = Resources.Load<GameObject>(theThingToFind); // load the prefab from resources
                Debug.LogError($"ok so the GameObject prefab is {prefab}");
    
                if (prefab != null) 
                {
                    // Load the saved position BEFORE instantiating
                    PlayerData data = Saving.LoadData(objectName); // load the data using the helper method
                    Vector3 savedPosition = (data != null) ? 
                        new Vector3(data.position[0], data.position[1], data.position[2]) : 
                        Vector3.zero; // if theres no data set it at zero

                    existingObject = Instantiate(prefab, savedPosition, Quaternion.identity); // instantiate the go with the data
                    existingObject.name = objectName; 
                    Tile tile = existingObject.GetComponent<Tile>();
                    if (tile != null)
                    {
                        // set the rest of the variables, if the object is a tile
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
            // logging
            Saving.Load(existingObject);
            Debug.Log(existingObject.name + " loaded");
        }
    }
}


