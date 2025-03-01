using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        
        #if UNITY_EDITOR // only runs in the editor.
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
