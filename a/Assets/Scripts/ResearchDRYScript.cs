using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.EventSystems;

[Serializable]
public class ResearchDRYScript : MonoBehaviour
{
    public int researchCost;
    private Stats stats;
    private GameObject statsObject;
    public bool isResearched;
    private bool isResearchIsApplied = false;
    public string theMethodToRun;
    public List<ResearchDRYScript> requiredResearch = new();
    private bool canBeResearched = true;

    private Transform canvasTransform;
    
    [SerializeField] private GameObject researchWindowObject;

    public void OnRightClick(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        if (ped.button.ToString() == "Right")
        {
            Debug.Log("right clicked");
            GameObject go = Instantiate(researchWindowObject, new Vector2(1158, 507), Quaternion.identity, canvasTransform);
            SeResearchData researchData = go.GetComponent<SeResearchData>();
            researchData.researchPoints = researchCost;
        }
    }
    
    void Start()
    {
        GameObject canvas = GameObject.FindWithTag("canvas");
        canvasTransform = canvas.GetComponent<Transform>();
        
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
            if (Application.isEditor)
            {
                Debug.Log("hehe");
            }
        }
    }


    /*GameObject obj = hitCollider.gameObject;
                ResearchDRYScript researchScript = obj.GetComponent<ResearchDRYScript>();
                GameObject go = Instantiate(researchWindowObject, obj.transform.position, Quaternion.identity, canvasTransform);
                SeResearchData seResearchData = go.GetComponent<SeResearchData>();
                seResearchData.researchPoints = researchCost;*/

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
                if (Application.isEditor)
                {
                    Debug.Log("not everything required was researched");
                }
            }
        }
        
        if (stats.researchPointsInStock >= researchCost && !isResearched && canBeResearched)
        {
            stats.researchPointsInStock -= researchCost;
            isResearched = true;
            if (Application.isEditor)
            {
                Debug.Log("Researched");
            }
            runTheMethod();
        }
        else
        {
            if (Application.isEditor)
            {
                Debug.Log("Did not research");
            }
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
        if (Application.isEditor)
        {
            Debug.Log("Great! the current cooldown is: " + stats.globalWoodMinerCooldown);
        }
    }

    void upgradeStonecutter()
    {
        stats.globalStoneMinerCooldown -= 0.5f;
    }

    void upgradeArtificialWoodcutter()
    {
        stats.globalArtificialWoodMinerCooldown -= 1f;
    }

    void upgradeArtificialStoneMine()
    {
        stats.globalArtificialStoneMinerCooldown -= 1f;
    }

    void unlockMarket()
    {
        stats.marketUnlocked = true;
    }
}
