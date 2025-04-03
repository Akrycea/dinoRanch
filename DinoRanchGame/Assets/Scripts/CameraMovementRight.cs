using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovementRight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseRover = false;

    void Update()
    {
 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseRover = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseRover = false;

    }


}
