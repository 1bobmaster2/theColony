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
            objectName = Regex.Replace(objectName, @"\d", "");
            GameObject existingObject = GameObject.Find(objectName);

            if (existingObject == null) // If the object doesn't exist, instantiate it
            {
                GameObject prefab = Resources.Load<GameObject>(objectName);
                if (prefab != null)
                {
                    existingObject = Instantiate(prefab);
                    existingObject.name = objectName; // Ensure correct name
                }
                else
                {
                    Debug.LogError("Prefab not found in Resources: " + objectName);
                    continue;
                }
            }

            Saving.Load(existingObject);
            Debug.Log(existingObject.name + " loaded");
        }
    }
}


