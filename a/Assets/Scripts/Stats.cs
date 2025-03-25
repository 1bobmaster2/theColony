using UnityEngine;

[System.Serializable]
public class Stats : MonoBehaviour
{
    // the stats
    public int woodInStock;
    public int humansInStock;
    public int foodInStock;
    public int totalhumansInStock;
    public int stoneInStock;
    public int researchPointsInStock;

    public float globalWoodMinerCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalhumansInStock = humansInStock; 
        
        // deleted the unused don't destroy on load
    }

    // Update is called once per frame
    void Update()
    {
        totalhumansInStock = humansInStock; // moved this to update
        
        
        if (Input.GetKeyDown(KeyCode.Space)) // log all of the stats, currently not useful, but im keeping it here
        {
            Debug.Log("You have:");
            Debug.Log(woodInStock + " wood");
            Debug.Log(humansInStock + " humans");
            Debug.Log(foodInStock + " food");
            Debug.Log(totalhumansInStock + " total humans");
        }
    }
}
