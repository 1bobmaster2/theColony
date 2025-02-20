
using System;


[Serializable]
public class PlayerData // this class had to be renamed because of a bug
{
    public int woodOnTree;
    public int woodInStock;
    public int foodInStock;
    public int humansInStock;
    public int totalhumansInStock;
    public bool isTree;
    public float[] position;
    public string name;

    // Modified constructor to accept data directly
    public PlayerData(string name, int woodOnTree, int woodInStock, int foodInStock,
        int humansInStock, int totalhumansInStock, bool isTree, float[] position)
    {
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
