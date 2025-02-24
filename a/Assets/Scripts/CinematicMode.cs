using UnityEngine;

public class CinematicMode : MonoBehaviour
{
    public GameObject canvas; // reference to the canvas object
    private bool isCinematic = false; // pre setting the isCinematic variable

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!isCinematic)
            {
                isCinematic = true;
                canvas.SetActive(false); //make ui invisible when F1 is pressed
            }
            else
            {
                isCinematic = false;
                canvas.SetActive(true); // make ui visible when F1 is pressed
            }
        }
    }
}
