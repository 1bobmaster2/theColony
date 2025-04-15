using System;
using System.Collections;
using UnityEngine;

public class houseScript : MonoBehaviour
{
    private Tile cell; // reference to the Tile bellow
    public Stats stats; // reference to the stats
    public int woodCost = 20; // cost

    [SerializeField] LayerMask layerMask;
    void OnDestroy()
    {
        cell.isOccupied = false;
    }
    
    void Start()
    {
        // get the stats
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();

        CheckBelow(); // check if theres a tile bellow
        StartCoroutine(createHumans());
        
        // there was a bunch of redudndant code but i removed it
    }
    
    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // get the position
        Collider2D hit = Physics2D.OverlapPoint(belowPosition, layerMask); // check if theres something bellow

        if (hit == null) // if there isn't log an error
        {
            if (Application.isEditor)
            {
                Debug.LogError("No Tile found at house position!");
            }
            return;
        }

        if (Application.isEditor)
        {
            Debug.Log("succes");
        }
        cell = hit.GetComponent<Tile>(); // get the tile
    }

    IEnumerator createHumans()
    {
        while (true)
        {
            if (stats.foodInStock >= 5)
            {
                // create humans and take food
                stats.foodInStock -= 5; 
                stats.humansInStock++;
                stats.totalhumansInStock++;
                if (Application.isEditor)
                {
                    Debug.Log("Human created! Food left: " + stats.foodInStock);
                }
            }
            else
            {
                if (Application.isEditor)
                {
                    Debug.Log("Not enough food to create human.");
                }
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void OnMouseDown()
    {
        // delete the house and give back half of the cost
        stats.woodInStock += 10;
        if (cell == null)
        {
            if (Application.isEditor)
            {
                Debug.Log("cell is null!");
            }
            return;
        }

        cell.isOccupied = false;
        Destroy(gameObject);
    }
}
