using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovementLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseLover = false;

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseLover = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseLover = false;

    }


}
