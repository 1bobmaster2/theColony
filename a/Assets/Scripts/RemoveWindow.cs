using UnityEngine;

public class RemoveWindow : MonoBehaviour
{
    [SerializeField] private Tutorial tutorial;
    public void Delete()
    {
        if (gameObject.name == "TutorialWindow")
        {
            tutorial.anyMoreTutorial = false;
        }
        Destroy(this.gameObject);
    }
}
