using UnityEngine;

public class EnableDisableResearchUI : MonoBehaviour
{
    [SerializeField] GameObject ResearchUIObject;
    [SerializeField] GameObject BaseUI;
    bool isOpen = false;

    public void EnableDisableResearchUIMethod()
    {
        if (isOpen == false)
        {
            isOpen = true;
            ResearchUIObject.SetActive(true);
            BaseUI.SetActive(false);
        }
        else
        {
            isOpen = false;
            ResearchUIObject.SetActive(false);
            BaseUI.SetActive(true);
        }
    }
}
