using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragInventoryBullet : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 originPos = new Vector2();
    private Vector2 temp = new Vector2();
    private DragManager dragManager;
    private Image image;
    public Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        dragManager = GameObject.Find("DragManager").GetComponent<DragManager>();
        originPos = transform.localPosition;
        image = transform.GetComponent<Image>();
        image.raycastTarget = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragManager.TurnOnArea(dragManager.SellArea);
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)//드래그중 위치 변경
    {
        temp = mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = temp;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Shop")) Destroy(gameObject);
        }
        transform.localPosition = originPos;
        image.raycastTarget = true;//돌아가고 레이케스트 다시 활성화
        dragManager.TurnOffArea(dragManager.SellArea);
    }
}
