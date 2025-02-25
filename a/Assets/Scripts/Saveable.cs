using UnityEngine;

public class Saveable : MonoBehaviour
{
    public string prefabName; // the name of the prefab
    public int id; // the id
    void Awake()
    {
        //string key = "obj_" + GetInstanceID(); // UNUSED
        string key = "obj_" + gameObject.transform.position.x + "_" + gameObject.transform.position.y+"_"+gameObject.name;
        // check if there is an id already
        if (PlayerPrefs.HasKey(key))
        {
            // if there is set the id to the key
            id = PlayerPrefs.GetInt(key);
        }
        else
        {
            // generate a new id
            id = Random.Range(0, 999999);
            PlayerPrefs.SetInt(key, id);
        }
        if (string.IsNullOrEmpty(prefabName))
        {
            prefabName = gameObject.name.Replace("(Clone)", "").Trim(); // set the prefab name correctly
        }

    }
}
