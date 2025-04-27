using System.Collections;
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
    private Text textOfTutorialWindow;
    private bool woodMinerExists, farmExists;
    private bool coroutineFinished;
    
    private GameObject tutorialWindowInstantiated;
    void Start()
    {
        Invoke(nameof(StartTutorialing), 5f);
    }

    void StartTutorialing()
    {
        tutorialWindowInstantiated = Instantiate(tutorialWindow, tutorialPosition, tutorialRotation, tutorialUIParentObject);
        tutorialWindowInstantiated.GetComponent<RectTransform>().anchoredPosition = tutorialPosition;
        textOfTutorialWindow = GetChildTextWithTag(tutorialWindowInstantiated, "tutorialText");
        MoveOntoNextTutorialText(0);
    }

    void MoveOntoNextTutorialText(int index)
    {
        textOfTutorialWindow.text = tutorialTexts[index];
    }

    IEnumerator MoveOntoNextTutorialTextCoroutine(int index)
    {
        coroutineFinished = false;
        yield return new WaitForSeconds(5f);
        textOfTutorialWindow.text = tutorialTexts[index];
        yield return new WaitForSeconds(5f);
        coroutineFinished = true;
    }
    
    void Update()
    {
        if (isPlacedDownCheckByTag("woodMiner") && !woodMinerExists)
        {
            woodMinerExists = true;
            MoveOntoNextTutorialText(1);
            if (!coroutineFinished)
            {
                StartCoroutine(MoveOntoNextTutorialTextCoroutine(2));
            }
        }
        else if (coroutineFinished && !farmExists)
        {
            MoveOntoNextTutorialText(3);
        }

        if (isPlacedDownCheckByTag("farm") && !farmExists)
        {
            farmExists = true;
            MoveOntoNextTutorialText(4);
            StartCoroutine(MoveOntoNextTutorialTextCoroutine(5));
        }
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

    bool isPlacedDownCheckByTag(string tagOfGo)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tagOfGo);
        if (objects.Length == 0)
        {
            return false;
        }
        return true;
    }
}
