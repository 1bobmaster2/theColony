using UnityEngine;
using UnityEngine.UI;

public class textUpdater : MonoBehaviour
{
    [SerializeField] private Text woodText, humanText, foodText, stoneText; // reference to the texts
    public Stats stats; // reference to the stats
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // get the stats
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the text on the Texts using the variables from the stats
        woodText.text = stats.woodInStock.ToString();
        humanText.text = $"{stats.humansInStock.ToString()} ({stats.totalhumansInStock.ToString()})";
        foodText.text = stats.foodInStock.ToString();
        stoneText.text = stats.stoneInStock.ToString();
    }
}
