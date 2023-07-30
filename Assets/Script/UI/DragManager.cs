using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DragManager : MonoBehaviour
{
    public Image SellArea;
    public Image ScreenDragArea;
    private Transform DragManagerCanvas;
    private void Awake()
    {
        DragManagerCanvas = transform.Find("Canvas");
        SellArea = DragManagerCanvas.Find("SellArea").GetComponent<Image>();
    }
    public void TurnOnArea(Image Area = null)
    {
        if (Area != null) Area.raycastTarget = true;
    }
    public void TurnOffArea(Image Area = null)
    {
        if (Area != null) Area.raycastTarget = false;
    }
}
