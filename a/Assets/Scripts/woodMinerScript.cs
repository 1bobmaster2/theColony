using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class woodMinerScript : MonoBehaviour
{
    private Tile cell;
    public Stats stats;
    public int woodCost = 10;
    public int humanCost = 3;


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
                if (cell.isTree == true && cell.isOccupied == false)
                {
                    if (Application.isEditor)
                    {
                        Debug.Log("Tree detected below!");
                    }
                }
                else
                {
                    if (Application.isEditor)
                    {
                        Debug.Log("No tree below.");
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
        
            yield return new WaitForSeconds(stats.globalWoodMinerCooldown);
        }
    }

    private void OnMouseDown()
    {
        stats.woodInStock += 5;
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
