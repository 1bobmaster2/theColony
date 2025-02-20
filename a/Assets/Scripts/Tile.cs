using System;
using UnityEngine;
[System.Serializable]
public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private Color treeColor;
    [SerializeField] private Color desolateTreeColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    public bool isTree;
    public bool isOccupied;
    public Tree thisTree; // Field to store the tree instance
    public Stats currentStats;
    public int woodOnTree;

    public void Start()
    {
        if (currentStats == null)
        {
            GameObject statsObject = GameObject.FindWithTag("statsManager");
        
            if (statsObject != null)
            {
                
                currentStats = statsObject.GetComponent<Stats>();
            
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

    void Update()
    {
        
    }

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    public void randomizeMaterial()
    {
        int random = UnityEngine.Random.Range(0, 100);
        if (random == 1)
        {
            isTree = true;
            spriteRenderer.color = treeColor;
            thisTree = new Tree(); // Store the Tree instance
            Debug.Log("Created a tree");
        }
    }

    public void OnMouseDown()
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
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
