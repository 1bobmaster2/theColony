using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public int moveSpeed; // speed of movement
    public Camera cam;
    private Vector3 dragOrigin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * (moveSpeed * Time.deltaTime * cam.orthographicSize)); // move up when w is pressed
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime * cam.orthographicSize)); // move down when s is pressed
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime * cam.orthographicSize)); // move left when a is pressed
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime * cam.orthographicSize)); // move right when d is pressed
        }

        PanCamera();
    }

    void PanCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }
}
