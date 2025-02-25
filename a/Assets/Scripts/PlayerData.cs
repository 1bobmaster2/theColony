using System;


[Serializable]
public class PlayerData // this class had to be renamed because of a bug
{
    // all of the variables required for saving
    public int woodOnTree;
    public int woodInStock;
    public int foodInStock;
    public int humansInStock;
    public int totalhumansInStock;
    public bool isTree;
    public float[] position;
    public string name;
    
    public PlayerData(string name, int woodOnTree, int woodInStock, int foodInStock,
        int humansInStock, int totalhumansInStock, bool isTree, float[] position)
    {
        // set the variables that are required for saving in the constructor
        this.name = name;
        this.woodOnTree = woodOnTree;
        this.woodInStock = woodInStock;
        this.foodInStock = foodInStock;
        this.humansInStock = humansInStock;
        this.totalhumansInStock = totalhumansInStock;
        this.isTree = isTree;
        this.position = position;
    }
}
