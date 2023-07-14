using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletCollision : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Bullet bulletScript;
    private Vector2 lastVel;
    Vector2 xNormal = new Vector2(1f, 0f);
    Vector2 yNormal = new Vector2(0f, 1f);
    Vector2 bulletPos;
    Vector2 colPoint;
    Vector2 normalVec;
    Vector2 dir;
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
        bulletPos = transform.position;
        colPoint = collision.contacts[0].point;
        normalVec = collision.contacts[0].normal;
        dir = new Vector2();
        dir = Vector2.Reflect(lastVel, normalVec.normalized);


        if (Vector3.Cross(bulletPos - colPoint, lastVel).z > 0)//�ݽð�
        {
            if (Vector3.Cross(lastVel, dir).z > 0)//�ݽð� ���� ����(���� 180���� �Ѿ)
            {
                //Debug.Log("nclLeft");
                dir = lastVel;
            }
            else if (lastVel.magnitude == rigidbody.velocity.magnitude)
            {
                oneFrameCol();
            }
        }
        else//�ð�
        {
            if (Vector3.Cross(lastVel, dir).z < 0)//�ð� ���� ������(���� 180���� �Ѿ)
            {
                //Debug.Log("clRight");
                dir = lastVel;
            }
            else if (lastVel.magnitude == rigidbody.velocity.magnitude)
            {
                oneFrameCol();
            }
        }
        /*
        if(dir.x == 0 || dir.y == 0)
        {
            console();
        }
        */
        rigidbody.velocity = dir;//���� ��찡 �ƴϸ� ����ϰ� �ݻ簢 ����


        if (collision.transform.CompareTag("Monster"))
        {
            collision.transform.GetComponent<IMonsterCollision>().UpdateHp(bulletScript.power);
        }
    }
    public void oneFrameCol()
    {
        if (lastVel.x * rigidbody.velocity.x < 0)//����� ������� ������ ������鿡 �΋H��
        {
            if (Mathf.Abs(normalVec.x) > Mathf.Abs(normalVec.y))//�������Ͱ� ������鿡 �΋H������ �˷���
            {
                //Debug.Log("case1");
                dir = rigidbody.velocity;
            }
            else//�������
            {
                //Debug.Log("case2");
                dir = Vector2.Reflect(rigidbody.velocity, yNormal);
            }
        }
        else
        {
            if (Mathf.Abs(normalVec.x) > Mathf.Abs(normalVec.y))//�������Ͱ� ������鿡 �΋H������ �˷���
            {
                //Debug.Log("case3");
                dir = Vector2.Reflect(rigidbody.velocity, xNormal);
            }
            else//�������
            {
                //Debug.Log("case4");
                dir = Vector2.Reflect(lastVel, yNormal);
            }
        }
    }
    public void console()
    {
        Debug.Log("rigidbodyVel:" + rigidbody.velocity);
        Debug.Log("lastVel:" + lastVel);
        Debug.Log("normalVec:" + normalVec.normalized);
        Debug.Log("dir:" + dir);
    }
}
