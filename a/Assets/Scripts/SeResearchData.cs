using UnityEngine;
using UnityEngine.UI;

public class SeResearchData : MonoBehaviour
{
    [SerializeField] private Text researchPointsText;
    public int researchPoints;

    void Start()
    {
        researchPointsText.text = "Cost: " + researchPoints;
    }
}
