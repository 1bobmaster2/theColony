using UnityEngine;

public class placeWoodMine : MonoBehaviour
{
    [SerializeField] public GameObject woodMine, farm, house;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Detect when the player presses "1"
        {
            PlaceTreeMine();
            Saving.RegisterObject(woodMine);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlaceFarm();
            Saving.RegisterObject(farm);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlaceHouse();
            Saving.RegisterObject(house);
        }
    }
    
    void PlaceTreeMine()
    {
        if (woodMine == null) return; // Prevent errors if prefab is not assigned

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Snap to grid by rounding to the nearest integer
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // reused woodMinerScript 13th line
        Tile cell = hit.GetComponent<Tile>();
        if (cell.isTree == true && cell.isOccupied == false)
        {
            Instantiate(woodMine, snappedPosition, Quaternion.identity); // Place prefab
            cell.isOccupied = true;
        }
    }

    void PlaceFarm()
    {
        if (farm == null) return;
        
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // reused woodMinerScript 13th line
        Tile cell = hit.GetComponent<Tile>();
        if (cell.isTree == false && cell.isOccupied == false)
        {
            Instantiate(farm, snappedPosition, Quaternion.identity); // Place prefab
            cell.isOccupied = true;
            Debug.Log("placed farm");
        }
        else
        {
            Debug.Log("did not placed farm");
        }
    }

    void PlaceHouse()
    {
        if (house == null) return;
        
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // reused woodMinerScript 13th line
        Tile cell = hit.GetComponent<Tile>();
        if (cell.isTree == false && cell.isOccupied == false)
        {
            Instantiate(house, snappedPosition, Quaternion.identity); // Place prefab
            cell.isOccupied = true;
            Debug.Log("placed house");
        }
        else
        {
            Debug.Log("did not place house");
        }
    }
}
