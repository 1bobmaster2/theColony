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
    
    public void AssingResearchPoints(int researchCost)
    {
        if (stats.researchPointsInStock - researchCost <= 0)
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
