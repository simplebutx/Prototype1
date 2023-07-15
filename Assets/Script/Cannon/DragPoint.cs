using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DragPoint : MonoBehaviour//맵 전체에 투명한 평면 드래그하여 총알 방향을 정함
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
            this.gameObject.SetActive(false);
        }
        else
        {
            clear = false;
        }
    }
    private void OnMouseUp()//드래그가 끝나면 총알 인스턴스화 시작
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
