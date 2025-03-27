using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Reflection;

[Serializable]
public class ResearchDRYScript : MonoBehaviour
{
    [SerializeField] private int researchCost;
    private Stats stats;
    private GameObject statsObject;
    public bool isResearched;
    private bool isResearchIsApplied = false;
    public string theMethodToRun;
    public List<ResearchDRYScript> requiredResearch = new List<ResearchDRYScript>();
    private bool canBeResearched = true;

    void Start()
    {
        statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
        Invoke(nameof(CheckAndApply), 3f);
    }

    void CheckAndApply()
    {
        if (isResearched)
        {
            runTheMethod();
        }
        else
        {
            Debug.Log("hehe");
        }
    }

    public void AssingResearchPoints()
    {
        canBeResearched = true;
        
        foreach (ResearchDRYScript r in requiredResearch)
        {
            if (r.isResearched == true)
            {
                continue;
            }
            else
            {
                canBeResearched = false;
                Debug.Log("not everything required was researched");
            }
        }
        
        if (stats.researchPointsInStock >= researchCost && !isResearched && canBeResearched)
        {
            stats.researchPointsInStock -= researchCost;
            isResearched = true;
            Debug.Log("Researched");
            runTheMethod();
        }
        else
        {
            Debug.Log("Did not research");
        }
    }

    void runTheMethod()
    {
        MethodInfo method = GetType().GetMethod(theMethodToRun, BindingFlags.NonPublic | BindingFlags.Instance);
        
        method.Invoke(this, null);
    }

    void upgradeWoodcutter()
    {
        stats.globalWoodMinerCooldown -= 0.5f;
        Debug.Log("Great! the current cooldown is: " + stats.globalWoodMinerCooldown);
    }

    void upgradeStonecutter()
    {
        stats.globalStoneMinerCooldown -= 0.5f;
    }
}
