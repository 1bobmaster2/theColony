using System;
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
    private void Awake()
    {
        
        if (!string.IsNullOrEmpty(buildingName))
        {
            nameText.text = buildingName;
        }
    
        
        if (woodCost != 0)
        {
            woodCostText.text = woodCost.ToString();
        }
    
        
        if (humanCost != 0)
        {
            humanCostText.text = humanCost.ToString();
        }
    
        
        if (stoneCost != 0)
        {
            stoneCostText.text = stoneCost.ToString();
        }
    
        
        if (!string.IsNullOrEmpty(canBePlacedOn))
        {
            canBePlacedOnText.text = canBePlacedOn;
        }
    }
}
