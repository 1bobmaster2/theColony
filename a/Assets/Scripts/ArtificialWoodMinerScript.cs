using System.Collections;
using UnityEngine;

public class ArtificialWoodMinerScript : MonoBehaviour
{
    private Tile cell;
    public Stats stats;
    public int woodCost = 15;
    public int humanCost = 4;


    [SerializeField] private LayerMask layerMask;
    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
        CheckBelow();
        StartCoroutine("mineTree"); 
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
                if (cell.isTree == false && cell.isOccupied == false)
                {
                    if (Application.isEditor)
                    {
                        Debug.Log("can spawn!");
                    }
                }
                else
                {
                    if (Application.isEditor)
                    {
                        Debug.Log("cant spawn because its either occupied or is a tree or some stone idk this shi.");
                    }
                }
            }
        }
    }


    IEnumerator mineTree()
    {
        while (true)
        {
            stats.woodInStock++;
            if (Application.isEditor)
            {
                Debug.Log("ok now we're gonan wait for " + stats.globalArtificialWoodMinerCooldown);
            }
            yield return new WaitForSeconds(stats.globalArtificialWoodMinerCooldown);
        }
    }

    private void OnMouseDown()
    {
        stats.woodInStock += 7;
        stats.humansInStock += humanCost;
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
