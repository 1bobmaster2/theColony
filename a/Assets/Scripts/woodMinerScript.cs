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
        Collider2D hit = Physics2D.OverlapPoint(belowPosition); // Detect object at that position

        if (hit != null)
        {
            cell = hit.GetComponent<Tile>(); 
            if (cell != null)
            {
                if (cell.isTree == true && cell.isOccupied == false)
                {
                    Debug.Log("Tree detected below!");

                }
                else
                {
                    Debug.Log("No tree below.");
                }
            }
        }
    }


    IEnumerator mineTree()
    {
        while (true)
        {
            stats.woodInStock++;
        
            yield return new WaitForSeconds(5);
        }
    }

    private void OnMouseDown()
    {
        stats.woodInStock += 5;
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
