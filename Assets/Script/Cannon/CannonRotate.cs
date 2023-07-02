using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    public Transform dragPoint;
    private Vector3 direction = new Vector3();
    private int rotateSpeed = 20;

    private void Update()//�巡�� ����Ʈ ������ �޾ƿ� ĳ�� ��������Ʈ ���� ����
    {
        direction = dragPoint.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }
}
