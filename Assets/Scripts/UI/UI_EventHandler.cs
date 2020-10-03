using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler, IPointerDownHandler, IEndDragHandler, IPointerUpHandler
{
    public Action<PointerEventData> OnPointerDownAction = null;
    public Action<PointerEventData> OnPointerUpAction = null;
    public Action<PointerEventData> OnPointerClickAction = null;
    public Action<PointerEventData> OnBeginDragAction = null;
    public Action<PointerEventData> OnDragAction = null;
    public Action<PointerEventData> OnEndDragAction = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownAction != null)
        {
            OnPointerDownAction.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointerClickAction != null)
        {
            OnPointerClickAction.Invoke(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragAction != null)
        {
            OnBeginDragAction.Invoke(eventData);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragAction != null)
        {
            OnDragAction.Invoke(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragAction != null)
        {
            OnEndDragAction.Invoke(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpAction != null)
        {
            OnPointerUpAction.Invoke(eventData);
        }
    }
}
