using UnityEngine;

public class RemoveWindow : MonoBehaviour
{
    public void Delete()
    {
        if (gameObject.name == "TutorialWindow")
        {
            Tutorial.anyMoreTutorial = false;
        }
        Destroy(this.gameObject);
    }
}
