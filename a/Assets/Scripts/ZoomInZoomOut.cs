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
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 1000);
        zoomInValue = cam.orthographicSize;
    }
}
