using UnityEngine;

[System.Serializable]
public class Stats : MonoBehaviour
{
    public int woodInStock;
    public int humansInStock;
    public int foodInStock;
    public int totalhumansInStock;
    public static Stats instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalhumansInStock = humansInStock;


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You have:");
            Debug.Log(woodInStock + " wood");
            Debug.Log(humansInStock + " humans");
            Debug.Log(foodInStock + " food");
            Debug.Log(totalhumansInStock + " total humans");
            
            
            
        }
    }
}
