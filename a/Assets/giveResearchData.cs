using UnityEngine;
using UnityEngine.EventSystems;

public class giveResearchData : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ResearchDRYScript researchScript;
    [SerializeField] private GameObject researchInfoWindow;
    [SerializeField] private Transform parent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("hi");
            GameObject go = Instantiate(researchInfoWindow, parent);
            SeResearchData seResearchData = go.GetComponent<SeResearchData>();
            seResearchData.researchPoints = researchScript.researchCost;
        }
    }
}
