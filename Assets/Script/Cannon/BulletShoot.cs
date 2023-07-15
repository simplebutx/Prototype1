using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject bulletCopy;
    private Transform dragPoint;
    public ChooseBullet chooseBullet;
    public GameObject choosedBullet;

    private void Start()
    {
        dragPoint = transform.Find("DragPoint");
        
    }

    public void choose()
    {
        choosedBullet = chooseBullet.GetComponent<ChooseBullet>().choosedBullet;
        bulletPrefab = Resources.Load(choosedBullet.name) as GameObject;
    }


    public void InstantiateBullet()//�Ѿ� �ν��Ͻ�ȭ �� ���� ����
    {
        bulletCopy = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletCopy.GetComponent<Bullet>().direction = dragPoint.position - transform.position;
    }
}
