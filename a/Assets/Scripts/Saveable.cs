using UnityEngine;

public class Saveable : MonoBehaviour
{
    public string prefabName;
    public int id;
    void Awake()
    {
        //string key = "obj_" + GetInstanceID(); // UNUSED
        string key = "obj_" + gameObject.transform.position.x + "_" + gameObject.transform.position.y+"_"+gameObject.name;
        // Check if ID already exists in PlayerPrefs
        if (PlayerPrefs.HasKey(key))
        {
            // Load existing ID
            id = PlayerPrefs.GetInt(key);
        }
        else
        {
            // Generate new unique ID and save it
            id = Random.Range(0, 999999);
            PlayerPrefs.SetInt(key, id);
        }
        if (string.IsNullOrEmpty(prefabName))
        {
            prefabName = gameObject.name.Replace("(Clone)", "").Trim(); // Set prefab name automatically
        }
        prefabName += id;
    }
    
}
