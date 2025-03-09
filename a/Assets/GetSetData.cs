using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetData : MonoBehaviour
{
    public List<bool> hasData = new List<bool>();
    public string buildingName, canBePlacedOn;
    public int woodCost, humanCost, stoneCost;
    private int heightDifference = -50;
    public Text nameText, woodCostText, humanCostText, stoneCostText, canBePlacedOnText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
