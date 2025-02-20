using System;
using System.Collections;
using UnityEngine;

public class houseScript : MonoBehaviour
{
    private Tile cell;
    public Stats stats;
    public int woodCost = 20;

    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();

        CheckBelow();

        if (stats.woodInStock >= woodCost)
        {
            stats.woodInStock -= woodCost;
            Debug.Log("Wood deducted. New wood count: " + stats.woodInStock);
            StartCoroutine(createHumans());
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("House destroyed due to lack of wood.");
            cell.isOccupied = false;
        }

        // Fix visibility issue
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = "Default";
            sr.sortingOrder = 5;
        }
        else
        {
            Debug.LogError("No SpriteRenderer found on house!");
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();

        // Optional: Modify collider properties
        boxCollider.size = new Vector2(1, 1);
    }
    void OnDestroy()
    {
        Saving.UnregisterObject(gameObject);
    }
    private void Update()
    {
        
    }

    void CheckBelow()
    {
        Vector2 belowPosition = new Vector2(transform.position.x, transform.position.y);
        Collider2D hit = Physics2D.OverlapPoint(belowPosition);

        if (hit == null)
        {
            Debug.LogError("No Tile found at house position!");
            return;
        }
        else
        {
            Debug.Log("succes");
        }

        cell = hit.GetComponent<Tile>();
    }

    IEnumerator createHumans()
    {
        while (true)
        {
            if (stats.foodInStock >= 5)
            {
                stats.foodInStock -= 5; // Corrected from stats.woodInStock = -5;
                stats.humansInStock++;
                stats.totalhumansInStock++;
                Debug.Log("Human created! Food left: " + stats.foodInStock);
            }
            else
            {
                Debug.Log("Not enough food to create human.");
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void OnMouseDown()
    {
        stats.woodInStock = stats.woodInStock + 10;
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
