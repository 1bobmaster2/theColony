using UnityEngine;

public class CinematicMode : MonoBehaviour
{
    public GameObject canvas;
    private bool isCinematic = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!isCinematic)
            {
                isCinematic = true;
                canvas.SetActive(false);
            }
            else
            {
                isCinematic = false;
                canvas.SetActive(true);
            }
        }
    }
}
