using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LooseCondition : MonoBehaviour
{
    public Stats stats;
    private string hexColor = "#F5FF00";
    public Text foodLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Eat());
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.foodInStock <= stats.totalhumansInStock)
        {
            foodLabel.color = Color.red;
        }
        else
        {
            if (ColorUtility.TryParseHtmlString(hexColor, out Color newColor) && foodLabel !=null )
            {
                foodLabel.color = newColor;
            }
            else
            {
                // Handle the case where the hex color is invalid
                //Debug.Log("Invalid hex color: " + hexColor + "or its null");
            }
        }
    }

    IEnumerator Eat()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            stats.foodInStock -= stats.totalhumansInStock;
            if (stats.foodInStock <= 0)
            {
                SceneManager.LoadScene(0);
                stats.foodInStock = 50; // required for correct initaliziation of game
            }
            else
            {
                Debug.Log("survived");
            }
            
        }
    }
}
