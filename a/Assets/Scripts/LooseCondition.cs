using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LooseCondition : MonoBehaviour
{
    public Stats stats; // reference to the stats
    private string hexColor = "#F5FF00"; // reference to the hex colour 
    public Text foodLabel; // reference to the text
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Eat()); // start the coRoutine
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.foodInStock <= stats.totalhumansInStock)
        {
            foodLabel.color = Color.red; // if there isnt enough food to survive the next day set the color to red
        }
        else
        {
            if (ColorUtility.TryParseHtmlString(hexColor, out Color newColor) && foodLabel !=null )
            {
                // if there is just set the color to its original color
                foodLabel.color = newColor;
            }
        }
    }

    IEnumerator Eat()
    {
        while (true)
        {
            // take the food, and if the food goes bellow zero load the scene (restart)
            yield return new WaitForSeconds(60f);
            stats.foodInStock -= stats.totalhumansInStock;
            if (stats.foodInStock <= 0)
            {
                DeleteSaves();
                SceneManager.LoadScene(0);
                // stats.foodInStock = 50; // required for correct initaliziation of game but probably redundant now
            }
            else
            {
                if (Application.isEditor)
                {
                    Debug.Log("survived"); // logging
                }
            }
            
        }
    }

    void DeleteSaves()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.dat");

        foreach (string file in files)
        {
            File.Delete(file);
        }
    }
}
