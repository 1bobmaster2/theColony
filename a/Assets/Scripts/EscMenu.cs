using UnityEngine;

public class EscMenu : MonoBehaviour
{
    [SerializeField] GameObject escMenu;
    bool escMenuOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !escMenuOpen)
        {
            escMenu.SetActive(true);
            escMenuOpen = true;
            TogglePause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escMenuOpen)
        {
            escMenu.SetActive(false);
            escMenuOpen = false;
            ToggleUnpause();
        }
    }
    
    void TogglePause()
    {
        Time.timeScale = 0;
    }

    void ToggleUnpause()
    {
        Time.timeScale = 1;
    }
}
