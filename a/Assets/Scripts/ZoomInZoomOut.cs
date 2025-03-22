using UnityEngine;

public class ZoomInZoomOut : MonoBehaviour
{
    public Camera cam;
    public float zoomInValue;
    public float zoomMultiplier;

    // Update is called once per frame
    void Update()
    {
        cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * zoomMultiplier;
        zoomInValue = cam.orthographicSize;
    }
}
