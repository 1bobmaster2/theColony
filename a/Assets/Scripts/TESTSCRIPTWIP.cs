using UnityEngine;
using UnityEngine.EventSystems;

public class TESTSCRIPTWIP : MonoBehaviour
{
    public void Click(BaseEventData bed)
    {
        PointerEventData ped = (PointerEventData)bed;
        Debug.Log("Button: "+ped.button.ToString());
    }
}
