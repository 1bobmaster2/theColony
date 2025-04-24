using UnityEngine;

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
        
    }
}
