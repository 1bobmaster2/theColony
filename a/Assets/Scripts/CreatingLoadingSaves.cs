using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;


public class CreatingLoadingSaves : MonoBehaviour
{
    private static readonly object fileLock = new object();
    public GameObject[] allGO; // array of every gameObject in the scene
    public Stats statsitself; // reference to the stats
    public Text savedText;
    public Text deletedSaveText;
    public GameObject Question;

    private string presistentDataPath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame(); // load the game on start
        presistentDataPath = Application.persistentDataPath;
    }

    private struct SaveDataContainer
    {
        public GameObject go;
        public string prefabName;
        public string id;
        public bool isTree;
        public bool isStone;
        public int woodOnTree;
        public int woodInStock;
        public int foodInStock;
        public int humansInStock;
        public int stoneInStock;
        public int researchPointsInStock;
        public int totalhumansInStock;
        public float[] position;
        public bool isResearched;
    }
    
    
    public async void ProcessGameObjects()
    {
        GameObject[] allGo = Resources.FindObjectsOfTypeAll<GameObject>(); // updated, also now gets objects that are disabled! do you like it guys? 
        // are you proud of me???? :3

        List<SaveDataContainer> saveDataList = new List<SaveDataContainer>();

        
        foreach (GameObject obj in allGo)
        {
            Saveable saveable = obj.GetComponent<Saveable>();
            
            if (saveable == null)
                continue;

            Tile tile = obj.GetComponent<Tile>();
            
            Stats stats = obj.GetComponent<Stats>();
            
            ResearchDRYScript researchScript = obj.GetComponent<ResearchDRYScript>();
            float[] pos = { obj.transform.position.x, obj.transform.position.y, obj.transform.position.z };

            SaveDataContainer data = new SaveDataContainer
            {
                go = obj,
                prefabName = saveable.prefabName,
                id = saveable.id,
                isTree = (tile != null && tile.isTree),
                isStone = (tile != null && tile.isStone),
                woodOnTree = (tile != null && tile.isTree) ? tile.woodOnTree : 0,
                woodInStock = stats != null ? stats.woodInStock : 0,
                foodInStock = stats != null ? stats.foodInStock : 0,
                humansInStock = stats != null ? stats.humansInStock : 0,
                stoneInStock = stats != null ? stats.stoneInStock : 0,
                researchPointsInStock = stats != null ? stats.researchPointsInStock : 0,
                totalhumansInStock = stats != null ? stats.totalhumansInStock : 0,
                position = pos,
                isResearched = researchScript != null && researchScript.isResearched
            };

            saveDataList.Add(data);
        }

        
        int processorCount = System.Environment.ProcessorCount;
        int chunkSize = saveDataList.Count / processorCount;
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < processorCount; i++)
        {
            int startIndex = i * chunkSize;
            int endIndex = (i == processorCount - 1) ? saveDataList.Count : startIndex + chunkSize;
            List<SaveDataContainer> chunk = saveDataList.Skip(startIndex).Take(endIndex - startIndex).ToList();

            tasks.Add(Task.Run(() =>
            {
                foreach (var data in chunk)
                {
                    
                    string combinedName = data.prefabName + data.id;
                    PlayerData playerData = new PlayerData(
                        combinedName,
                        data.woodOnTree,
                        data.woodInStock,
                        data.foodInStock,
                        data.humansInStock,
                        data.stoneInStock,
                        data.researchPointsInStock,
                        data.totalhumansInStock,
                        data.isTree,
                        data.isStone,
                        data.position,
                        data.isResearched
                    );

                    
                    BinaryFormatter bf = new BinaryFormatter();
                    string path = presistentDataPath + "/" + data.prefabName+data.id + ".dat";
                    
                    lock (fileLock)
                    {
                        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            bf.Serialize(stream, playerData);
                        }
                    }
                    
                }
            }));
        }

        await Task.WhenAll(tasks);
        EnableSavedPopup();
    }

    void EnableSavedPopup()
    {
        savedText.color = new Color(savedText.color.r, savedText.color.g, savedText.color.b, 1f);
        savedText.enabled = true;
        Invoke("DisableSavedPopup", 3.0f);
    }

    void DisableSavedPopup()
    {
        StartCoroutine(FadeOutSavedText());
    }

    void EnableDeletedSavePopup()
    {
        deletedSaveText.color = new Color(deletedSaveText.color.r, deletedSaveText.color.g, deletedSaveText.color.b, 1f);
        deletedSaveText.enabled = true;
        Invoke("DisableDeletedSavePopup", 3.0f);
    }

    void DisableDeletedSavePopup()
    {
        StartCoroutine(FadeOutDeletedText());
    }
    
    IEnumerator FadeOutSavedText()
    {
        float duration = 1f; 
        float elapsedTime = 0f;
        float startAlpha = savedText.color.a;
        float endAlpha = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; 
            float alpha = Mathf.SmoothStep(startAlpha, endAlpha, t);
            savedText.color = new Color(savedText.color.r, savedText.color.g, savedText.color.b, alpha);
            yield return null;
        }

        savedText.color = new Color(savedText.color.r, savedText.color.g, savedText.color.b, endAlpha);
        savedText.enabled = false;
    }
    
    IEnumerator FadeOutDeletedText()
    {
        float duration = 1f; 
        float elapsedTime = 0f;
        float startAlpha = deletedSaveText.color.a;
        float endAlpha = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; 
            float alpha = Mathf.SmoothStep(startAlpha, endAlpha, t);
            deletedSaveText.color = new Color(deletedSaveText.color.r, deletedSaveText.color.g, deletedSaveText.color.b, alpha);
            yield return null;
        }

        deletedSaveText.color = new Color(deletedSaveText.color.r, deletedSaveText.color.g, deletedSaveText.color.b, endAlpha);
        deletedSaveText.enabled = false;
    }

    public void AskToDeleteSaves() // this method is not unused.
    {
        Question.SetActive(true);
    }

    public void DeleteSaves()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.dat");

        foreach (string file in files)
        {
            File.Delete(file);
        }
        Question.SetActive(false);
        EnableDeletedSavePopup();
    }
    
    public void LoadGame()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.dat"); // get all the files

        foreach (string file in files)
        {
            string objectName = Path.GetFileNameWithoutExtension(file).Replace(".dat", ""); // get the object
            Debug.LogError("current object name is equal to: " + objectName);
            string fixedObjectname = Regex.Replace(objectName, @"[a-fA-F0-9\-]{36}$", ""); // get the object name without guid
            Debug.LogError("current object name is equal to: " + fixedObjectname);
            GameObject existingObject = GameObject.Find(fixedObjectname); // check if the object (without id) already exists in the scene
            
            if (existingObject == null) // if it doesnt instantiate it
            {
                string theThingToFind = Regex.Replace(objectName, @"[a-fA-F0-9\-]{36}$", ""); // get the object name without guid
                Debug.LogError(theThingToFind + " ohio baka ");
                GameObject prefab = Resources.Load<GameObject>(theThingToFind); // load the prefab from resources
                Debug.LogError($"ok so the GameObject prefab is {prefab}");
    
                if (prefab != null) 
                {
                    // Load the saved position BEFORE instantiating
                    PlayerData data = Saving.LoadData(objectName); // load the data using the helper method
                    Vector3 savedPosition = (data != null) ? 
                        new Vector3(data.position[0], data.position[1], data.position[2]) : 
                        Vector3.zero; // if there is no data set it at zero

                    existingObject = Instantiate(prefab, savedPosition, Quaternion.identity); // instantiate the go with the data
                    Tile tile = existingObject.GetComponent<Tile>();
                    if (tile != null)
                    {
                        // set the rest of the variables if the object is a tile
                        tile.isTree = data.isTree; 
                        tile.woodOnTree = data.woodOnTree;
                        tile.isStone = data.isStone;
                    }
                    
                    ResearchDRYScript researchScript = existingObject.GetComponent<ResearchDRYScript>();
                    if (researchScript != null)
                    {
                        researchScript.isResearched = data.isResearched;
                    }
                }
                else
                {
                    Debug.LogWarning("Prefab not found in Resources: " + theThingToFind);
                    continue;
                }
            }
            else
            {
                Saving.Load(existingObject);
            }
            // logging
            Debug.Log(existingObject.name + " loaded");
        }
    }
}


