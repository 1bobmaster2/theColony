using UnityEngine;

public class PosFixUIPanel : MonoBehaviour
{
    public RectTransform desiredPosition; // the desired position
    public Vector2 desiredPositionVector; // the desired position, but in vector 2 variable


    // Update is called once per frame
    void Update()
    {
        // set the desire position right
        desiredPosition.anchoredPosition = desiredPositionVector;
    }
}
