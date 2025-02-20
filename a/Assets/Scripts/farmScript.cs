using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class farmScript : MonoBehaviour
{
    private Tile cell;
    public Stats stats;
    public int woodCost = 15;
    public int humanCost = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
        CheckBelow();
        if (stats.woodInStock >= woodCost && stats.humansInStock >= humanCost)
        {
            stats.humansInStock -= humanCost;
            stats.woodInStock -= woodCost;
            StartCoroutine(farm());
        }
        else
        {
            Destroy(gameObject);
            cell.isOccupied = false;
        }
        
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();

        // Optional: Modify collider properties
        boxCollider.size = new Vector2(1, 1);
    }

    void OnDestroy()
    {
        Saving.UnregisterObject(gameObject);
    }
    
    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // Get the cell below
        Collider2D hit = Physics2D.OverlapPoint(belowPosition); // Detect object at that position

        cell = hit.GetComponent<Tile>();
    }

    IEnumerator farm()
    {
        while (true)
        {
            stats.foodInStock++;
            yield return new WaitForSeconds(2);
        }
    }
    
    private void OnMouseDown()
    {
        stats.woodInStock = stats.woodInStock + 7;
        stats.humansInStock = stats.humansInStock + humanCost;
        if (cell == null)
        {
            Debug.Log("cell is null!");
            return;
        }
        else
        {
            cell.isOccupied = false;
        }

        Destroy(gameObject);
    }
}
