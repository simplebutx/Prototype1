using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 originPos = new Vector2();
    private Vector2 temp = new Vector2();
    private Image image;
    public Camera mainCamera;
    private void Awake()
    {
        originPos = transform.localPosition;
        image = transform.GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        temp = mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = temp;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = originPos;
        image.raycastTarget = true;
    }
}
