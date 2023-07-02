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
        var dir = Vector2.Reflect(lastVel, collision.contacts[0].normal);//평면 충돌시 입사각의 반사각으로 방향을 계산하여 속도 그대로 유지
        rigidbody.velocity = dir;
        if (collision.gameObject.CompareTag("Monster"))//충돌한 물체가 몬스터이면 충돌인터페이스를 받아와 hp업데이트
        {
            collision.transform.GetComponent<IMonsterCollision>().UpdateHp(bulletScript.power);
        }
    }
}
