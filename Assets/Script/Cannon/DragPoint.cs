using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragPoint : MonoBehaviour//�� ��ü�� ������ ��� �巡�� �Ͽ� �Ѿ� ������ ����
{
    public Vector2 originPos;
    private BulletShoot bulletShoot;
    private void Start()
    {
        bulletShoot = transform.parent.GetComponent<BulletShoot>();
        originPos = transform.position;
    }
    private void OnMouseUp()//�巡�װ� ������ �Ѿ� �ν��Ͻ�ȭ ����
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
