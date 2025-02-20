using UnityEngine;

public class PosFixUIPanel : MonoBehaviour
{
    public RectTransform desiredPosition;
    public Vector2 desiredPositionVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredPosition.anchoredPosition = desiredPositionVector;
        Debug.Log("set the desired position");
    }
}
