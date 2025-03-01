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
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escMenuOpen)
        {
            escMenu.SetActive(false);
            escMenuOpen = false;
        }
    }

}
