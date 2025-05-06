using UnityEngine;

public class marketWindowScript : MonoBehaviour
{
    private int amountOfWood;
    private int amountOfStone;
    private int amountOfFood;
    private bool marketMode; // TRUE IS BUY FALSE IS SELL !!!!!!
    private Stats stats;

    void Awake()
    {
        GameObject go = GameObject.FindWithTag("statsManager");
        stats = go.GetComponent<Stats>();
        if (Application.isEditor)
        {
            Debug.Log("market found stats succesfully");
        }
    }
    
}
