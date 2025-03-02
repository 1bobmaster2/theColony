using System;
using UnityEngine;

public class Saveable : MonoBehaviour
{
    public string prefabName; // the name of the prefab
    public string id; // the id
    void Awake()
    {
        string key = "obj_" + gameObject.transform.position.x + "_" + gameObject.transform.position.y+"_"+gameObject.name+"hiiiiuwu";
        // check if there is an id already
        if (PlayerPrefs.HasKey(key))
        {
            // if there is set id to the key
            id = PlayerPrefs.GetString(key);
        }
        else
        {
            // generate a new id
            id = Guid.NewGuid().ToString();
            PlayerPrefs.SetString(key, id);
        }
        if (string.IsNullOrEmpty(prefabName))
        {
            prefabName = gameObject.name.Replace("(Clone)", "").Trim(); // set the prefab name correctly
        }

    }
}
