using System;
using UnityEngine;
[System.Serializable]
public class Tile : MonoBehaviour
{
    // all the colours for tile
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private Color treeColor;
    [SerializeField] private Color stoneColor;
    [SerializeField] private Color desolateTreeColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    // other variables should be self-explanatory
    public bool isTree;
    public bool isStone;
    public bool isOccupied;
    public Tree thisTree;  // redundant
    public Stats currentStats;
    public int woodOnTree;

    private void Awake()
    {
        var isOffset = (gameObject.transform.position.x % 2 == 0 && gameObject.transform.position.y % 2 != 0) || (gameObject.transform.position.y % 2 == 0 && gameObject.transform.position.x % 2 != 0); // check if its offset
        Init(isOffset); // change its color based of the offset
        
    }

    private void Update()
    {
        if (isTree)
        {
            spriteRenderer.color = treeColor;
        }
        else if (isStone)
        {
            spriteRenderer.color = stoneColor;
        }
    }

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
                    if (Application.isEditor)
                    {
                        Debug.LogError("Found the GameObject, but no Stats component attached.");

                    }
                }
                else
                {
                    if (Application.isEditor)
                    {
                        Debug.Log("Successfully assigned currentStats from the GameObject.");

                    }
                }
            }
            else
            {
                if (Application.isEditor)
                {
                    Debug.LogError("No GameObject with the 'Stats' tag found in the scene.");
                }
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
            if (Application.isEditor)
            {
                Debug.Log("Created a tree");
            }
        }
        else if (random == 2)
        {
            isStone = true;
            spriteRenderer.color = stoneColor;
        }
    }
    
    // not used
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
