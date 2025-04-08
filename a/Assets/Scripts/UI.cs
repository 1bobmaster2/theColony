using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject options;

    public void EnableControls()
    {
        controls.SetActive(true);
        menu.SetActive(false);
        options.SetActive(false);
    }

    void DisableControls()
    {
        if (controls.activeInHierarchy)
        {
            controls.SetActive(false);
            menu.SetActive(false);
            options.SetActive(true);
        }
    }

    public void EnableOptions()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }

    public void DisableOptions()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
    
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableControls();
        }

        if (options.activeInHierarchy)
        {
            menu.SetActive(false);
        }
    }
}
