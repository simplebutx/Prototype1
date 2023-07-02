using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletCollision : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Bullet bulletScript;
    private Vector2 lastVel;
    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        bulletScript = transform.GetComponent<Bullet>();
    }
    private void LateUpdate()
    {
        lastVel = rigidbody.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var dir = Vector2.Reflect(lastVel, collision.contacts[0].normal);//��� �浹�� �Ի簢�� �ݻ簢���� ������ ����Ͽ� �ӵ� �״�� ����
        rigidbody.velocity = dir;
        if (collision.gameObject.CompareTag("Monster"))//�浹�� ��ü�� �����̸� �浹�������̽��� �޾ƿ� hp������Ʈ
        {
            collision.transform.GetComponent<IMonsterCollision>().UpdateHp(bulletScript.power);
        }
    }
}
