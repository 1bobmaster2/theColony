using System.Collections.Generic;
using UnityEngine;

public class GiveData : MonoBehaviour
{
    [SerializeField] private GameObject window;
    private List<bool> hasData = new List<bool>();
    private string buildingName;
    private string canBePlacedOn;
    private int woodCost;
    private int humanCost;
    private int stoneCost;
    private string parentName;
    
    public void CreateTheObjectAndGiveData()
    {
        string parentName = gameObject.name;
        switch (parentName)
        {
            case "CreateWoodCutterInfo":
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(false); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Wood Cutter";
                canBePlacedOn = "Forest";
                woodCost = 10;
                humanCost = 3;
                GameObject go = Instantiate(window);
                GetSetData gsd = go.GetComponent<GetSetData>();
                gsd.hasData = hasData;
                gsd.canBePlacedOn = canBePlacedOn;
                gsd.buildingName = buildingName;
                gsd.woodCost = woodCost;
                gsd.humanCost = humanCost;
                break;
            case "CreateFarmInfo":
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(false); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Farm";
                canBePlacedOn = "Anywhere";
                woodCost = 15;
                humanCost = 2;
                GameObject go1 = Instantiate(window);
                GetSetData gsd1 = go1.GetComponent<GetSetData>();
                gsd1.hasData = hasData;
                gsd1.canBePlacedOn = canBePlacedOn;
                gsd1.buildingName = buildingName;
                gsd1.woodCost = woodCost;
                gsd1.humanCost = humanCost;
                break;
            case "CreateStoneCollectorInfo":
                hasData.Add(true);
                hasData.Add(false); // this is wood
                hasData.Add(true);
                hasData.Add(true); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Stone Collector";
                canBePlacedOn = "Stone";
                humanCost = 2;
                stoneCost = 22;
                GameObject go2 = Instantiate(window);
                GetSetData gsd2 = go2.GetComponent<GetSetData>();
                gsd2.hasData = hasData;
                gsd2.canBePlacedOn = canBePlacedOn;
                gsd2.buildingName = buildingName;
                gsd2.stoneCost = stoneCost;
                gsd2.humanCost = humanCost;
                break;
            case "CreateHouseInfo":
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(false);
                hasData.Add(false); // this is stone cost btw
                hasData.Add(true);
                buildingName = "House";
                canBePlacedOn = "Anywhere";
                woodCost = 20;
                GameObject go3 = Instantiate(window);
                GetSetData gsd3 = go3.GetComponent<GetSetData>();
                gsd3.hasData = hasData;
                gsd3.canBePlacedOn = canBePlacedOn;
                gsd3.buildingName = buildingName;
                gsd3.woodCost = woodCost;
                break;
        }
    }
}
