using UnityEngine;
using UnityEngine.EventSystems;

public class WindowMove : MonoBehaviour, IDragHandler, IPointerDownHandler {
    [SerializeField] RectTransform parent;
    [SerializeField] Canvas canvas;

    public void Start()
    {
        if (canvas == null)
        {
            GameObject canvasObj = GameObject.FindWithTag("canvas");
            canvas = canvasObj.GetComponent<Canvas>();
        }
    }
    
    public void OnDrag(PointerEventData eventData1)
    {
        parent.anchoredPosition += eventData1.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parent.SetAsLastSibling();
    }
}
