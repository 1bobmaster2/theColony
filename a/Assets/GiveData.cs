using System.Collections.Generic;
using UnityEngine;

public class GiveData : MonoBehaviour
{
    [SerializeField] private GameObject window;
    List<bool> hasData = new List<bool> {true,true,true,false,true};
    private string buildingName = "Wood Cutter";
    private string canBePlacedOn = "Forest";
    private int woodCost = 10;
    private int humanCost = 3;
    
    public void CreateTheObjectAndGiveData()
    {
        GameObject go = Instantiate(window);
        GetSetData gsd = go.GetComponent<GetSetData>();
        gsd.hasData = hasData;
        gsd.canBePlacedOn = canBePlacedOn;
        gsd.buildingName = buildingName;
        gsd.woodCost = woodCost;
        gsd.humanCost = humanCost;
    }
}
