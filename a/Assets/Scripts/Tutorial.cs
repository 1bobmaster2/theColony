using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private Transform tutorialUIParentObject;
    [Space]
    [SerializeField] private string[] tutorialTexts;
    private Vector3 tutorialPosition = new(537, 384, 0);
    private Quaternion tutorialRotation = Quaternion.identity;
    
    void Start()
    {
        Invoke(nameof(StartTutorialing), 5f);
    }

    void StartTutorialing()
    {
        GameObject tutorialWindowInstantiated = Instantiate(tutorialWindow, tutorialPosition, tutorialRotation, tutorialUIParentObject);
        tutorialWindowInstantiated.GetComponent<RectTransform>().anchoredPosition = tutorialPosition;
        Text textOfTutorialWindow = GetChildTextWithTag(tutorialWindowInstantiated, "tutorialText");
        textOfTutorialWindow.text = tutorialTexts[0]; // this sets the text of the text in the window to the first string in the list
    }
    
    Text GetChildTextWithTag(GameObject parent, string tagOfGo)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tagOfGo))
            {
                if (Application.isEditor)
                {
                    Debug.Log("found it");
                }
                return child.GetComponent<Text>();
            }
        }

        if (Application.isEditor)
        {
            Debug.Log("did not find it");
        }
        return null;
    }
}
