using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragPoint : MonoBehaviour//�� ��ü�� ������ ��� �巡�� �Ͽ� �Ѿ� ������ ����
{
    public Vector2 originPos;
    private BulletShoot bulletShoot;
    private bool clear = false;
    public GameObject turnProcess;
    private void Start()
    {
        bulletShoot = transform.parent.GetComponent<BulletShoot>();
        originPos = transform.position;
    }
    private void Update()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Monster");
        if (temp.Length.Equals(0))
        {
            clear = true;
            turnProcess.GetComponent<turnprogressbutton>().OnClick();
            //���� ���ٴϴ� �Ѿ˵� 
            this.gameObject.SetActive(false);
        }
        else
        {
            clear = false;
        }
    }
    private void OnMouseUp()//�巡�װ� ������ �Ѿ� �ν��Ͻ�ȭ ����
    {
        if (!clear)
        {
            bulletShoot.InstantiateBullet();
            transform.position = originPos;
        }
    }
    private void OnMouseDown()
    {
        if (!clear)
        {
            Vector2 objectPos = GetMouseWorldPosition();
            transform.position = objectPos;
        }
    }
    void OnMouseDrag()
    {
        if (!clear)
        {
            Vector2 objectPos = GetMouseWorldPosition();
            transform.position = objectPos;
        }
    }
    Vector2 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
