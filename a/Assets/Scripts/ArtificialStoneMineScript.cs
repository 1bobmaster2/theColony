using System.Collections;
using UnityEngine;

public class ArtificialStoneMineScript : MonoBehaviour
{
    private Tile cell;
    public Stats stats;
    public int stoneCost = 25;
    public int humanCost = 6;
    
    [SerializeField] LayerMask layerMask;
    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
        CheckBelow();
        StartCoroutine("mineStone"); 
    }
    void OnDestroy()
    {
        cell.isOccupied = false;
    }

    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // Get the cell below
        Collider2D hit = Physics2D.OverlapPoint(belowPosition, layerMask); // Detect object at that position

        if (hit != null)
        {
            cell = hit.GetComponent<Tile>(); 
            if (cell != null)
            {
                if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
                {
                    Debug.Log("Stone detected below!");

                }
                else
                {
                    Debug.Log("No Stone below.");
                }
            }
        }
    }


    IEnumerator mineStone()
    {
        while (true)
        {
            stats.stoneInStock += 2;
            Debug.Log(stats.globalArtificialStoneMinerCooldown);
            yield return new WaitForSeconds(stats.globalArtificialStoneMinerCooldown);
        }
    }

    private void OnMouseDown()
    {
        stats.stoneInStock += 17;
        stats.humansInStock += humanCost;
        if (cell == null)
        {
            Debug.Log("cell is null!");
            return;
        }

        cell.isOccupied = false;

        Destroy(gameObject);
    }
}
