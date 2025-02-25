using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    
    public GameObject exampleGO; // reference to a savefile
    [SerializeField] private int width, height; // dimensions of the grid
    [SerializeField] private Tile tilePrefab; // the thing that generateGrid() spawns
    [SerializeField] private Transform cam; // reference to the camera
    private Dictionary<Vector2, Tile> tiles = new(); // a hashmap of tiles

    private void Start()
    {
        if (!Saving.SaveExists(exampleGO)) // check if theres a savefile, if the isnt create a grid
        {
            GenerateGrid();
        }
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity); // spawn the tile
                GameObject go = spawnedTile.gameObject;
                //Saving.RegisterObject(go); // register the tile
                
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (y % 2 == 0 && x % 2 != 0); // check if its offset
                spawnedTile.Init(isOffset); // change its colour based of the offset
                spawnedTile.randomizeMaterial(); // randomize the material
                
                tiles[new Vector2(x, y)] = spawnedTile; // add to the dictionary
            }
        }

        cam.transform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f, -10); // set the position of the camera to the middle of the grid
    }
}