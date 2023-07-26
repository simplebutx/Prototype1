using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector3 dragOrigin;
    private DragManager dragManager;
    private Camera mainCamera;
    [SerializeField] public float smoothness= 0.001f;

    private float minY = -4.25f; 
    private float maxY = 0;
    private void Start()
    {
        mainCamera = Camera.main;
        dragManager = GameObject.Find("DragManager").GetComponent<DragManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOrigin = eventData.position;
        dragManager.CheckDrag();
    }
    public void OnDrag(PointerEventData eventData)//드래그중 위치 변경
    {
        Vector3 currentPosition = eventData.position;
        Vector3 moveDirection = (currentPosition - dragOrigin) * smoothness;
        moveDirection.x = 0;

        Vector3 newPosition = mainCamera.transform.position - moveDirection;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        mainCamera.transform.position = newPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        dragManager.OnEndDrag();
    }
}
