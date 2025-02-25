using System;
using UnityEngine;
[System.Serializable]
public class Tile : MonoBehaviour
{
    // all of the colours for tile
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private Color treeColor;
    [SerializeField] private Color desolateTreeColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    // other variables, should be self explanatory
    public bool isTree;
    public bool isOccupied;
    public Tree thisTree; 
    public Stats currentStats;
    public int woodOnTree;

    public void Start()
    {
        if (currentStats == null)
        {
            GameObject statsObject = GameObject.FindWithTag("statsManager"); // get the stats if they don't exist
        
            if (statsObject != null)
            {
                currentStats = statsObject.GetComponent<Stats>();
            
                // logging for debugging
                if (currentStats == null)
                {
                    Debug.LogError("Found the GameObject, but no Stats component attached.");
                }
                else
                {
                    Debug.Log("Successfully assigned currentStats from the GameObject.");
                }
            }
            else
            {
                Debug.LogError("No GameObject with the 'Stats' tag found in the scene.");
            }
        }
    }
    
    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor; // set the color based on the offset
    }

    public void randomizeMaterial()
    {
        // randomize the material, 1 percent chance for a tile to be tree
        int random = UnityEngine.Random.Range(0, 100);
        if (random == 1)
        {
            isTree = true;
            spriteRenderer.color = treeColor;
            thisTree = new Tree(); // Store the Tree instance
            Debug.Log("Created a tree");
        }
    }
    
    // not really used
    /*public void OnMouseDown()
    {
        if (isTree)
        {
            if (thisTree != null)
            {
                
                //currentStats.woodInStock++;
                //thisTree.wood--;
            }
            else
            {
                Debug.Log("This is a tree, but the tree instance is missing.");
            }
        }
        else
        {
            Debug.Log("This is a tile.");
        }
    }*/
    
    // set the highlight when the player hovers over the Tile
    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
