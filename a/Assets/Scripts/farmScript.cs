using System.Collections;
using UnityEngine;

public class farmScript : MonoBehaviour
{
    private Tile cell; // reference to the tile bellow
    public Stats stats; // reference to the stats
    public int woodCost = 15; //cost
    public int humanCost = 2; //cost  


    void Awake()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager"); // get the stats
        stats = statsObject.GetComponent<Stats>(); // assign the stats
        CheckBelow();
        StartCoroutine("farm");
    }

    void OnDestroy()
    {
        cell.isOccupied = false;
    }
    
    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // get the cell below
        Collider2D hit = Physics2D.OverlapPoint(belowPosition); // check if there is something bellow
        if (hit == null)
        {
            Debug.LogError("farm did not found something below :(");
        }
        cell = hit.GetComponent<Tile>(); // get the tile
    }

    IEnumerator farm()
    {
        while (true)
        {
            // basic farm functions
            stats.foodInStock++;
            yield return new WaitForSeconds(2);
        }
    }
    
    private void OnMouseDown()
    {
        // removing the farm and giving the cost back
        stats.woodInStock += 7;
        stats.humansInStock += humanCost;
        if (cell == null)
        {
            Debug.Log("cell is null!");
            return;
        }

        cell.isOccupied = false; // make the cell unoccupied

        Destroy(gameObject);
    }
}
