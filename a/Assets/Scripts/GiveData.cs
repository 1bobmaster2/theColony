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
    public Canvas canvas;
    
    public void CreateTheObjectAndGiveData()
    {
        string parentName = gameObject.name;
        if (Application.isEditor)
        {
            Debug.LogError("ohio ligma balls");
        }
        switch (parentName)
        {
            case "CreateWoodCutterInfo":
                hasData.Clear();
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
                go.transform.SetParent(canvas.transform, false);
                gsd.hasData = hasData;
                gsd.canBePlacedOn = canBePlacedOn;
                gsd.buildingName = buildingName;
                gsd.woodCost = woodCost;
                gsd.humanCost = humanCost;
                break;
            case "CreateFarmInfo":
                hasData.Clear();
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
                go1.transform.SetParent(canvas.transform, false);
                gsd1.hasData = hasData;
                gsd1.canBePlacedOn = canBePlacedOn;
                gsd1.buildingName = buildingName;
                gsd1.woodCost = woodCost;
                gsd1.humanCost = humanCost;
                break;
            case "CreateStoneCollectorInfo":
                hasData.Clear();
                hasData.Add(true);
                hasData.Add(false); // this is wood
                hasData.Add(true);
                hasData.Add(true); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Stone Mine";
                canBePlacedOn = "Stone";
                humanCost = 2;
                stoneCost = 22;
                GameObject go2 = Instantiate(window);
                GetSetData gsd2 = go2.GetComponent<GetSetData>();
                go2.transform.SetParent(canvas.transform, false);
                gsd2.hasData = hasData;
                gsd2.canBePlacedOn = canBePlacedOn;
                gsd2.buildingName = buildingName;
                gsd2.stoneCost = stoneCost;
                gsd2.humanCost = humanCost;
                break;
            case "CreateHouseInfo":
                hasData.Clear();
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
                go3.transform.SetParent(canvas.transform, false);
                gsd3.hasData = hasData;
                gsd3.canBePlacedOn = canBePlacedOn;
                gsd3.buildingName = buildingName;
                gsd3.woodCost = woodCost;
                break;
            case "CreateResearchInfo":
                hasData.Clear();
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Research Facility";
                canBePlacedOn = "Anywhere";
                woodCost = 10;
                stoneCost = 10;
                humanCost = 5;
                GameObject go4 = Instantiate(window);
                GetSetData gsd4 = go4.GetComponent<GetSetData>();
                go4.transform.SetParent(canvas.transform, false);
                gsd4.hasData = hasData;
                gsd4.canBePlacedOn = canBePlacedOn;
                gsd4.buildingName = buildingName;
                gsd4.woodCost = woodCost;
                gsd4.stoneCost = stoneCost;
                gsd4.humanCost = humanCost;
                break;
            case "CreateArtificialWoodCutterInfo":
                hasData.Clear();
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(false); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Artificial Wood Cutter";
                canBePlacedOn = "Anywhere";
                woodCost = 15;
                humanCost = 4;
                GameObject go5 = Instantiate(window);
                GetSetData gsd5 = go5.GetComponent<GetSetData>();
                go5.transform.SetParent(canvas.transform, false);
                gsd5.hasData = hasData;
                gsd5.canBePlacedOn = canBePlacedOn;
                gsd5.buildingName = buildingName;
                gsd5.woodCost = woodCost;
                gsd5.humanCost = humanCost;
                break;
            case "CreateArtificialStoneMineInfo":
                hasData.Clear();
                hasData.Add(true);
                hasData.Add(false); // this is wood
                hasData.Add(true);
                hasData.Add(true); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Artificial Stone Mine";
                canBePlacedOn = "Anywhere";
                humanCost = 6;
                stoneCost = 25;
                GameObject go22 = Instantiate(window);
                GetSetData gsd22 = go22.GetComponent<GetSetData>();
                go22.transform.SetParent(canvas.transform, false);
                gsd22.hasData = hasData;
                gsd22.canBePlacedOn = canBePlacedOn;
                gsd22.buildingName = buildingName;
                gsd22.stoneCost = stoneCost;
                gsd22.humanCost = humanCost;
                break;
            case "CreateMarketInfo":
                hasData.Clear();
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(true);
                hasData.Add(false); // this is stone cost btw
                hasData.Add(true);
                buildingName = "Market";
                canBePlacedOn = "Anywhere";
                woodCost = 30;
                humanCost = 10;
                GameObject go7 = Instantiate(window);
                GetSetData gsd7 = go7.GetComponent<GetSetData>();
                go7.transform.SetParent(canvas.transform, false);
                gsd7.hasData = hasData;
                gsd7.canBePlacedOn = canBePlacedOn;
                gsd7.buildingName = buildingName;
                gsd7.woodCost = woodCost;
                gsd7.humanCost = humanCost;
                break;
            default:
                if (Application.isEditor)
                {
                    Debug.LogError("hi");
                }
                break;
        }
    }
}
