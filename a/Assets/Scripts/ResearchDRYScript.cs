using UnityEngine;

public class ResearchDRYScript : MonoBehaviour
{
    [SerializeField] private int researchCost;
    private Stats stats;
    private GameObject statsObject;

    void Start()
    {
        statsObject = GameObject.FindWithTag("statsManager");
        stats = statsObject.GetComponent<Stats>();
    }
    
    public void AssingResearchPoints()
    {
        if (stats.researchPointsInStock >= researchCost )
        {
            stats.researchPointsInStock -= researchCost;
            Debug.Log("Researched");
        }
        else
        {
            Debug.Log("Did not research");
        }
    }
}
