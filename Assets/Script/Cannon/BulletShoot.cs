using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject bulletCopy;
    private Transform dragPoint;
    private void Start()
    {
        dragPoint = transform.Find("DragPoint");
        bulletPrefab = Resources.Load("Bullet") as GameObject;
    }
    public void InstantiateBullet()//총알 인스턴스화 및 방향 전달
    {
        bulletCopy = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletCopy.GetComponent<Bullet>().direction = dragPoint.position - transform.position;
    }
}
