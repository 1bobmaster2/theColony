using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class ResearchDRYScript : MonoBehaviour
{
    public int researchCost;
    private Stats stats;
    private GameObject statsObject;
    public bool isResearched;
    private bool isResearchIsApplied = false;
    public string theMethodToRun;
    public List<ResearchDRYScript> requiredResearch = new List<ResearchDRYScript>();
    private bool canBeResearched = true;

    private Transform canvasTransform;
    
    [SerializeField] private GameObject researchWindowObject;

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
            Debug.Log("hehe");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Debug.Log("clicked");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            Debug.Log(hitCollider);

           
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            
            RaycastResult uiRaycastResult = new RaycastResult();
            GraphicRaycaster graphicRaycaster = canvasTransform.GetComponent<GraphicRaycaster>();
            if (graphicRaycaster != null)
            {
                graphicRaycaster.Raycast(pointerData, new System.Collections.Generic.List<RaycastResult>());
                if (uiRaycastResult.gameObject != null) 
                {
                    Debug.Log("UI object clicked");
                    return; 
                }
            }

            
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                GameObject obj = hitCollider.gameObject;
                ResearchDRYScript researchScript = obj.GetComponent<ResearchDRYScript>();
                GameObject go = Instantiate(researchWindowObject, obj.transform.position, Quaternion.identity, canvasTransform);
                SeResearchData seResearchData = go.GetComponent<SeResearchData>();
                seResearchData.researchPoints = researchCost;
            }
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
