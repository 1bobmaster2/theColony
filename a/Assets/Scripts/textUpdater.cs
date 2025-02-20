using UnityEngine;
using UnityEngine.UI;

public class textUpdater : MonoBehaviour
{
    [SerializeField] private Text woodText, humanText, foodText;
    public Stats stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = stats.woodInStock.ToString();
        humanText.text = $"{stats.humansInStock.ToString()} ({stats.totalhumansInStock.ToString()})";
        foodText.text = stats.foodInStock.ToString();
    }
}
