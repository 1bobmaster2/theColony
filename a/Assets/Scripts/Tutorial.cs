using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private Transform tutorialUIParentObject;
    [Space]
    [SerializeField] private string tutorialText;
    private Vector3 tutorialPosition = new Vector3(409, 384, 0);
    private Quaternion tutorialRotation = Quaternion.identity;
    public static bool anyMoreTutorial;
    void Start()
    {
        StartTutorialing();
    }

    void StartTutorialing()
    {
        Instantiate(tutorialWindow, tutorialPosition, tutorialRotation, tutorialUIParentObject);
    }
}
