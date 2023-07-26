using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DragManager : MonoBehaviour
{
    public Image SellArea;
    public Image ScreenDragArea;
    private List<Image> managedAreas = new List<Image>();
    private Transform DragManagerCanvas;
    public bool IsOnDrag { get; protected set; }
    private void Awake()
    {
        IsOnDrag = false;
        DragManagerCanvas = transform.Find("Canvas");
        SellArea = DragManagerCanvas.Find("SellArea").GetComponent<Image>();
        ScreenDragArea = DragManagerCanvas.Find("ScreenDragPoint").GetComponent<Image>();
        managedAreas.Add(ScreenDragArea);
    }
    public bool CheckDrag(Image Area = null)
    {
        if (!IsOnDrag)
        {
            OnBeginDrag();
            if (Area != null) Area.raycastTarget = true;
            TurnOffArea();
            return true;
        }
        return false;
    }
    public void OnBeginDrag()
    {
        IsOnDrag = true;
    }
    public void OnEndDrag(Image Area = null)
    {
        if (Area != null) Area.raycastTarget = false;
        TurnOnArea();
        IsOnDrag = false;
    }
    public void TurnOffArea()
    {
        foreach (Image Area in managedAreas)
        {
            Area.raycastTarget = false;
        }
    }
    public void TurnOnArea()
    {
        foreach (Image Area in managedAreas)
        {
            Area.raycastTarget = true;
        }
    }
}
