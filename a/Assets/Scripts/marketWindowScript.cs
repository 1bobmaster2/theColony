using UnityEngine;
using UnityEngine.UI;

public class marketWindowScript : MonoBehaviour
{
    private int amountOfWood;
    private int amountOfStone;
    private int amountOfFood;
    private bool marketMode; // TRUE IS BUY FALSE IS SELL !!!!!!
    private Stats stats;
    [SerializeField] private InputField amountOfWoodInput, amountOfStoneInput, amountOfFoodInput;
    private int costOfWood = 5;
    private int costOfStone = 10;
    private int costOfFood = 1;


    void Awake()
    {
        GameObject go = GameObject.FindWithTag("statsManager");
        stats = go.GetComponent<Stats>();
        if (Application.isEditor)
        {
            Debug.Log("market found stats succesfully");
        }
    }

    void Update()
    {
        amountOfWood = int.Parse(amountOfWoodInput.text);
        amountOfStone = int.Parse(amountOfStoneInput.text);
        amountOfFood = int.Parse(amountOfFoodInput.text);
    }

    public void SetMarketMode(bool MarketMode)
    {
        marketMode = MarketMode;
    }

    public void DoMarketStuff()
    {
        if (marketMode) // this is buy
        {
            int cost = amountOfWood * costOfWood + amountOfFood * costOfFood + amountOfStone * costOfStone;
            // need to make money stat
            if (Application.isEditor)
            {
                Debug.Log("paid " + cost);
            }
            // if we have enough money of course
            stats.woodInStock += amountOfWood;
            stats.foodInStock += amountOfFood;
            stats.stoneInStock += amountOfStone;
        }
        else // this is sell
        {
            int profit = amountOfWood * costOfWood + amountOfFood * costOfFood + amountOfStone * costOfStone;
            if (amountOfWood <= stats.woodInStock && amountOfStone <= stats.stoneInStock && amountOfFood <= stats.foodInStock)
            {
                stats.woodInStock -= amountOfWood;
                stats.stoneInStock -= amountOfStone;
                stats.foodInStock -= amountOfFood;

                if (Application.isEditor)
                {
                    Debug.Log("got this much money " + profit);
                }
            }
            else
            {
                if (Application.isEditor)
                {
                    Debug.Log("not enough resources");
                }
            }
        }
    }
    
}
