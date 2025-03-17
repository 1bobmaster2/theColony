using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetData : MonoBehaviour
{

    public List<bool> hasData = new();

    public string buildingName, canBePlacedOn;
    public int woodCost, humanCost, stoneCost;


    private float spacing = 50f;

    private float startY = 50f;

    public Text nameText, woodCostText, humanCostText, stoneCostText, canBePlacedOnText;

    void Start()
    {
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        
        List<Text> activeTexts = new List<Text>();


        bool nameHasData = !string.IsNullOrEmpty(buildingName);
        hasData.Add(nameHasData);
        if (nameHasData)
        {
            nameText.text = "Name: " + buildingName;
            nameText.gameObject.SetActive(true);
            activeTexts.Add(nameText);
        }
        else
        {
            nameText.gameObject.SetActive(false);
        }

        bool woodHasData = woodCost != 0;
        hasData.Add(woodHasData);
        if (woodHasData)
        {
            woodCostText.text = "Wood cost: " + woodCost;
            woodCostText.gameObject.SetActive(true);
            activeTexts.Add(woodCostText);
        }
        else
        {
            woodCostText.gameObject.SetActive(false);
        }


        bool humanHasData = humanCost != 0;
        hasData.Add(humanHasData);
        if (humanHasData)
        {
            humanCostText.text = "Human cost: " + humanCost;
            humanCostText.gameObject.SetActive(true);
            activeTexts.Add(humanCostText);
        }
        else
        {
            humanCostText.gameObject.SetActive(false);
        }


        bool stoneHasData = stoneCost != 0;
        hasData.Add(stoneHasData);
        if (stoneHasData)
        {
            stoneCostText.text = "Stone cost: " + stoneCost;
            stoneCostText.gameObject.SetActive(true);
            activeTexts.Add(stoneCostText);
        }
        else
        {
            stoneCostText.gameObject.SetActive(false);
        }


        bool canBePlacedHasData = !string.IsNullOrEmpty(canBePlacedOn);
        hasData.Add(canBePlacedHasData);
        if (canBePlacedHasData)
        {
            canBePlacedOnText.text = "Can be placed on: " + canBePlacedOn;
            canBePlacedOnText.gameObject.SetActive(true);
            activeTexts.Add(canBePlacedOnText);
        }
        else
        {
            canBePlacedOnText.gameObject.SetActive(false);
        }


        for (int i = 0; i < activeTexts.Count; i++)
        {

            RectTransform rt = activeTexts[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, startY - (spacing * i));
        }
    }
}
