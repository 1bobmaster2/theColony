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
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.ohio");

        foreach (string file in files)
        {
            string objectName = System.IO.Path.GetFileNameWithoutExtension(file).Replace(".ohio", "");
            Debug.LogWarning("current object name is equal to: " + objectName);
            string fixedObjectname = Regex.Replace(objectName, @"\d", "");
            Debug.LogWarning("current object name is equal to: " + fixedObjectname);
            GameObject existingObject = GameObject.Find(fixedObjectname);

            Saveable saveable = null;
            try
            {
                saveable = existingObject.GetComponent<Saveable>();
            }
            catch (Exception e)
            {
                Debug.LogWarning("object is a prefab");
            }
            if (saveable == null)
            {
                existingObject = GameObject.Find(objectName);
                Debug.LogWarning("object is a prefab");
            }
            else
            {
                existingObject = GameObject.Find(fixedObjectname);
                Debug.LogWarning("object is not a prefab");
            }

            if (existingObject == null) // If the object doesn't exist, instantiate it
            {
                string theThingToFind = Regex.Replace(objectName, @"\d", "");
                GameObject prefab = Resources.Load<GameObject>(theThingToFind);
                if (prefab != null)
                {
                    existingObject = Instantiate(prefab);
                    existingObject.name = objectName; // Ensure correct name
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


