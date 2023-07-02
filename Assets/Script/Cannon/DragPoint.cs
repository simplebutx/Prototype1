using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragPoint : MonoBehaviour//맵 전체에 투명한 평면 드래그 하여 총알 방향을 정함
{
    public Vector2 originPos;
    private BulletShoot bulletShoot;
    private void Start()
    {
        bulletShoot = transform.parent.GetComponent<BulletShoot>();
        originPos = transform.position;
    }
    private void OnMouseUp()//드래그가 끝나면 총알 인스턴스화 시작
    {
        bulletShoot.InstantiateBullet();
        transform.position = originPos;
    }
    private void OnMouseDown()
    {
        Vector2 objectPos = GetMouseWorldPosition();
        transform.position = objectPos;
    }
    void OnMouseDrag()
    {
        Vector2 objectPos = GetMouseWorldPosition();
        transform.position = objectPos;
    }
    Vector2 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
