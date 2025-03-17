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
        Debug.LogError("ohio ligma balls");
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
                buildingName = "Stone Collector";
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
            default:
                Debug.LogError("hi");
                break;
        }
    }
}
