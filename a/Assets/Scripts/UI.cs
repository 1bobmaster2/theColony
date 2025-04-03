using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;

    public void EnableControls()
    {
        controls.SetActive(true);
        menu.SetActive(false);
    }

    void DisableControls()
    {
        if (controls.activeInHierarchy)
        {
            controls.SetActive(false);
            menu.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableControls();
        }
    }
}
