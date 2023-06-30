using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseUp : MonoBehaviour, IDropHandler {
    public UnityEvent onDropEvent = new UnityEvent();
    public void OnDrop(PointerEventData data)
    {
        onDropEvent.Invoke();
    }
}
