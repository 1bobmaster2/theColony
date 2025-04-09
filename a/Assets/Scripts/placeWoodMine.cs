using FMODUnity;
using UnityEngine;

// the name of this class isn't really right cuz its more for spawning every building and not just one btw
public class placeWoodMine  : MonoBehaviour
{
    public GameObject woodMine, farm, house, stoneMine, researchFacility, artificialWoodMiner, artificialStoneMine; // reference to the prefabs that get spawned
    public Stats stats;
    private int woodCostFarm = 15;
    private int woodCostHouse = 20;
    private int woodCostWoodcutter = 10;
    private int humanCostFarm = 2;
    private int humanCostWoodcutter = 3;
    private int stoneCostStoneMine = 22;
    private int humanCostStoneMine = 5;

    private int woodCostResearchFacility = 10;
    private int stoneCostResearchFacility = 10;
    private int humanCostResearchFacility = 5;

    private int woodCostArtificialWoodcutter = 15;
    private int humanCostArtificialWoodcutter = 4;

    private int stoneCostArtificialStoneMine = 25;
    private int humanCostArtificialStoneMine = 6;

    public UI soundThingy;
    
    public EventReference PlaceSound;

    void Start()
    {
        GameObject statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // place the tree mine and register it for saving when the player presses one 
        {
            PlaceTreeMine();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // place the farm and register it for saving when the player presses two
        {
            PlaceFarm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // place the house and register it for saving when the player presses three
        {
            PlaceHouse();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlaceStoneMine();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlaceResearchFacility();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlaceArtificialTreeMine();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlaceArtificialStoneMine();
        }
    }

    void PlaceArtificialStoneMine()
    {
        if (artificialStoneMine == null) return; // Prevent errors if prefab is not assigned

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse pos
        
        // snap to grid by rounding to the nearest integer
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y)); // get the snapped position
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // check if theres something bellow
        Tile cell = hit.GetComponent<Tile>(); // get the Tile bellow
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.stoneInStock >= stoneCostArtificialStoneMine && stats.humansInStock >= humanCostArtificialStoneMine)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.stoneInStock -= stoneCostArtificialStoneMine;
                stats.humansInStock -= humanCostArtificialStoneMine;
            }
            else
            {
                return;
            }
            
            Instantiate(artificialStoneMine, snappedPosition, Quaternion.identity); // place it if all conditions are met
            PlayPlaceSound();
            cell.isOccupied = true;
        }
    }
    
    void PlaceArtificialTreeMine()
    {
        if (artificialWoodMiner == null) return; // Prevent errors if prefab is not assigned

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse pos
        
        // snap to grid by rounding to the nearest integer
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y)); // get the snapped position
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // check if theres something bellow
        Tile cell = hit.GetComponent<Tile>(); // get the Tile bellow
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.woodInStock >= woodCostArtificialWoodcutter && stats.humansInStock >= humanCostArtificialWoodcutter)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.woodInStock -= woodCostArtificialWoodcutter;
                stats.humansInStock -= humanCostArtificialWoodcutter;
            }
            else
            {
                return;
            }
            
            Instantiate(artificialWoodMiner, snappedPosition, Quaternion.identity); // place it if all conditions are met
            PlayPlaceSound();
            cell.isOccupied = true;
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
        if (cell.isTree && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.woodInStock >= woodCostWoodcutter && stats.humansInStock >= humanCostWoodcutter)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.woodInStock -= woodCostWoodcutter;
                stats.humansInStock -= humanCostWoodcutter;
            }
            else
            {
                return;
            }
            
            Instantiate(woodMine, snappedPosition, Quaternion.identity); // place it if all conditions are met
            PlayPlaceSound();
            cell.isOccupied = true;
        }
    }
    
    void PlaceStoneMine()
    {
        if (stoneMine == null) return; // Prevent errors if prefab is not assigned

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse pos
        
        // snap to grid by rounding to the nearest integer
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y)); // get the snapped position
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // check if theres something bellow
        Tile cell = hit.GetComponent<Tile>(); // get the Tile bellow
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == true)
        {
            if (stats.stoneInStock >= stoneCostStoneMine && stats.humansInStock >= humanCostStoneMine)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.stoneInStock -= stoneCostStoneMine;
                stats.humansInStock -= humanCostStoneMine;
            }
            else
            {
                return;
            }
            
            Instantiate(stoneMine, snappedPosition, Quaternion.identity); // place it if all conditions are met
            PlayPlaceSound();
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
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.woodInStock >= woodCostFarm && stats.humansInStock >= humanCostFarm)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.woodInStock -= woodCostFarm;
                stats.humansInStock -= humanCostFarm;
            }
            else
            {
                return;
            }
            Instantiate(farm, snappedPosition, Quaternion.identity); // Place prefab
            PlayPlaceSound();
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
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.woodInStock >= woodCostHouse)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.woodInStock -= woodCostHouse;
            }
            else
            {
                return;
            }
            Instantiate(house, snappedPosition, Quaternion.identity); // Place prefab
            PlayPlaceSound();
            cell.isOccupied = true;
            Debug.Log("placed house");
        }
        else
        {
            Debug.Log("did not place house");
        }
    }
    
    void PlaceResearchFacility()
    {
        // the comments from the PlaceTreeMine() apply here so i wont rewrite them, the same goes for place house
        if (researchFacility == null) return;
        
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 snappedPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        Collider2D hit = Physics2D.OverlapPoint(snappedPosition); // reused woodMinerScript 13th line
        Tile cell = hit.GetComponent<Tile>();
        if (cell.isTree == false && cell.isOccupied == false && cell.isStone == false)
        {
            if (stats.woodInStock >= woodCostResearchFacility && stats.humansInStock >= humanCostResearchFacility && stats.stoneInStock >= stoneCostResearchFacility)
            {
                // if the user has enough material, deduct cost from stats and start the CoRoutine
                stats.woodInStock -= woodCostResearchFacility;
                stats.humansInStock -= humanCostResearchFacility;
                stats.stoneInStock -= stoneCostResearchFacility;
            }
            else
            {
                return;
            }
            Instantiate(researchFacility, snappedPosition, Quaternion.identity); // Place prefab
            PlayPlaceSound();
            cell.isOccupied = true;
            Debug.Log("placed farm");
        }
        else
        {
            Debug.Log("did not placed farm");
        }
    }

    void PlayPlaceSound()
    {
        FMOD.Studio.EventInstance PlaySoundInstance = RuntimeManager.CreateInstance(PlaceSound);
        PlaySoundInstance.setVolume(soundThingy.SoundVolume);
        PlaySoundInstance.start();
        PlaySoundInstance.release();
    }
}
