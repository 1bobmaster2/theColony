using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private Transform tutorialUIParentObject;
    [Space]
    [SerializeField] private string tutorialText;
    private Vector3 tutorialPosition = new(537, 384, 0);
    private Quaternion tutorialRotation = Quaternion.identity;
    public static bool anyMoreTutorial;
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
