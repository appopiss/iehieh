using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnterExitEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{
    public Action EnterEvent;
    public Action ExitEvent;
    public Action LeftClickEvent;
    public Action RightClickEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
            LeftClickEvent?.Invoke();
        else if(eventData.pointerId == -2)
            RightClickEvent?.Invoke();
    }

    public void OnPointerEnter(PointerEventData e)
    {
        EnterEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData e)
    {
        ExitEvent?.Invoke();
    }
}
