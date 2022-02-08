using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// Sets Handlers for Entering and Exiting UI Element
/// </summary>
public class OnUiHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent enterAction;
    public UnityEvent exitAction;

    public void OnPointerEnter(PointerEventData eventData)
    {
        enterAction.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitAction.Invoke();
    }


}
