using System.Collections;
using UnityEngine;

public class ResearchScript : MonoBehaviour
{
    private Tile cell; // reference to the tile bellow
    public Stats stats; // reference to the stats
    public int woodCost = 10; //cost
    public int stoneCost = 10;
    public int humanCost = 5; //cost  


    void Awake()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager"); // get the stats
        stats = statsObject.GetComponent<Stats>(); // assign the stats
        CheckBelow();
        StartCoroutine("generateResearch");
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

    IEnumerator generateResearch()
    {
        while (true)
        {
            // basic farm functions
            stats.researchPointsInStock++;
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    private void OnMouseDown()
    {
        // removing the farm and giving the cost back
        stats.woodInStock += 5;
        stats.stoneInStock += 5;
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
