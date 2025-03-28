using System.Collections.Generic;
using UnityEngine;

public class PosFixUIPanel : MonoBehaviour
{
    public RectTransform desiredPosition; // the desired position
    public Vector2 desiredPositionVector; // the desired position, but in vector 2 variable

    public bool isGroup;                                      //
    public List<GameObject> group = new List<GameObject>();
    void Update()
    {
        if (!isGroup)
        {
            // set the desire position right
            desiredPosition.anchoredPosition = desiredPositionVector;
        }
    }

    void OnEnable()
    {
        if (isGroup)
        {
            foreach (GameObject obj in group)
            {
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, 0);
            }
        }
    }
}
