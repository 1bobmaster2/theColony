using UnityEngine;

// the name of this class isnt really right cuz its more for spawning every building and not just one btw
public class placeWoodMine  : MonoBehaviour
{
    [SerializeField] public GameObject woodMine, farm, house; // reference to the prefabs that get spawned

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // place the tree mine and register it for saving when the player presses one 
        {
            PlaceTreeMine();
            Saving.RegisterObject(woodMine);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // place the farn and register it for saving when the player presses two
        {
            PlaceFarm();
            Saving.RegisterObject(farm);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // place the house and register it for saving when the player presses three
        {
            PlaceHouse();
            Saving.RegisterObject(house);
        }
    }
    
    void PlaceTreeMine()
    {
        if (woodMine == null) return; // Prevent errors if prefab is not assigned

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse pos
        
        // snap to grid by rounding to the nearest integer
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y)); // get the snapped position
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // check if theres something bellow
        Tile cell = hit.GetComponent<Tile>(); // get the Tile bellow
        if (cell.isTree == true && cell.isOccupied == false)
        {
            Instantiate(woodMine, snappedPosition, Quaternion.identity); // place it if all conditions are met
            cell.isOccupied = true;
        }
    }

    void PlaceFarm()
    {
        // the comments from the PlaceTreeMine() apply here so i wont rewrite them, the same goes for place house
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
