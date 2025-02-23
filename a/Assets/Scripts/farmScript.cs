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

    void Awake()
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
    }

    void OnDestroy()
    {
        Saving.UnregisterObject(gameObject);
    }
    
    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y); // Get the cell below
        Collider2D hit = Physics2D.OverlapPoint(belowPosition); // Detect object at that position
        if (hit == null)
        {
            Debug.LogError("farm did not found something below :(");
            Destroy(gameObject);
        }
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
