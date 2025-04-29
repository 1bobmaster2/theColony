using System.Collections;
using UnityEngine;

public class marketScript : MonoBehaviour
{
    private Tile cell; // reference to the tile bellow
    public Stats stats; // reference to the stats
    public int woodCost = 30; //cost
    public int humanCost = 10; //cost  

    [SerializeField] LayerMask layerMask;
    void Awake()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager"); // get the stats
        stats = statsObject.GetComponent<Stats>(); // assign the stats
        CheckBelow();
    }

    void OnDestroy()
    {
        cell.isOccupied = false;
    }
    
    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // get the cell below
        Collider2D hit = Physics2D.OverlapPoint(belowPosition, layerMask); // check if there is something bellow
        if (hit == null)
        {
            if (Application.isEditor)
            {
                Debug.LogError("farm did not found something below :(");
            }
        }
        cell = hit.GetComponent<Tile>(); // get the tile
    }
    
    
    private void OnMouseDown()
    {
        if (Application.isEditor)
        {
            Debug.Log("click lol");
        }
        // removing the farm and giving the cost back
        stats.woodInStock += 15;
        stats.humansInStock += humanCost;
        if (cell == null)
        {
            if (Application.isEditor)
            {
                Debug.Log("cell is null!");
            }
        }
        else
        {
            cell.isOccupied = false; // make the cell unoccupied
        }

        Destroy(gameObject);
    }
}