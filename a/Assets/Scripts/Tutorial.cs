using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private Transform tutorialUIObject;
    [Space]
    [SerializeField] private string tutorialText;

    public static bool anyMoreTutorial;
    void Start()
    {
        StartTutorialing();
    }

    void StartTutorialing()
    {
        Instantiate(tutorialWindow, tutorialUIObject);
    }
}
