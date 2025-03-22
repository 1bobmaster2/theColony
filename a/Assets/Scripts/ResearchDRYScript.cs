using System.Collections.Generic;

using UnityEngine;

public class ResearchDRYScript : MonoBehaviour
{
    [SerializeField] private int researchCost;
    private Stats stats;
    private GameObject statsObject;
    private bool isResearched;
    public List<ResearchDRYScript> requiredResearch = new List<ResearchDRYScript>();
    private bool canBeResearched = true;

    void Start()
    {
        statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
        
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
        }
        else
        {
            Debug.Log("Did not research");
        }
    }
}
