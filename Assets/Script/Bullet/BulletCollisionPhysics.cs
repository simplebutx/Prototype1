using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletCollisionPhysics : MonoBehaviour
{
    private Rigidbody2D rigidbody;
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
    }
    private void LateUpdate()
    {
        lastVel = rigidbody.velocity;
    }
    public bool CalculatePhysics(Collision2D collision)
    {
        bulletPos = transform.position;
        colPoint = collision.contacts[0].point;
        normalVec = collision.contacts[0].normal;
        dir = new Vector2();
        dir = Vector2.Reflect(lastVel, normalVec.normalized);


        if (Vector3.Cross(bulletPos - colPoint, lastVel).z > 0)//몬스터의 중심을 기준으로 총알의 방향이 반시계
        {
            if (Vector3.Cross(lastVel, dir).z > 0)//반시계 기준 왼쪽(각이 180도가 넘어감)
            {
                //Debug.Log("nclLeft");
                rigidbody.velocity = lastVel;
            }
            else if (lastVel.magnitude == rigidbody.velocity.magnitude)
            {
                return oneFrameCol();
            }
            else
            {
                rigidbody.velocity = dir;//앞의 경우가 아니면 평범하게 반사각 대입
            }
        }
        else//몬스터의 중심을 기준으로 총알의 방향이 시계
        {
            if (Vector3.Cross(lastVel, dir).z < 0)//시계 기준 오른쪽(각이 180도가 넘어감)
            {
                //Debug.Log("clRight");
                rigidbody.velocity = lastVel;
            }
            else if (lastVel.magnitude == rigidbody.velocity.magnitude)
            {
                return oneFrameCol();
            }
            else
            {
                rigidbody.velocity = dir;//앞의 경우가 아니면 평범하게 반사각 대입
            }
        }
        return false;
        /*
        if(dir.x == 0 || dir.y == 0)
        {
            console();
        }*/
    }
    public bool oneFrameCol()//1프레임내 2번의 충돌이 일어났을경우
    {
        if (lastVel.x * rigidbody.velocity.x < 0)//양수면 가로평면 음수면 세로평면에 부H힘
        {
            if (Mathf.Abs(normalVec.x) > Mathf.Abs(normalVec.y))//법선벡터가 세로평면에 부H혔음을 알려줌
            {
                //Debug.Log("case1");
                return true;
            }
            else//가로평면
            {
                //Debug.Log("case2");
                rigidbody.velocity = Vector2.Reflect(rigidbody.velocity, yNormal);
            }
        }
        else
        {
            if (Mathf.Abs(normalVec.x) > Mathf.Abs(normalVec.y))//법선벡터가 세로평면에 부H혔음을 알려줌
            {
                //Debug.Log("case3");
                rigidbody.velocity = Vector2.Reflect(rigidbody.velocity, xNormal);
            }
            else//가로평면
            {
                //Debug.Log("case4");
                rigidbody.velocity = Vector2.Reflect(lastVel, yNormal);
                return true;
            }
        }
        return false;
    }
    public void console()
    {
        Debug.Log("rigidbodyVel:" + rigidbody.velocity);
        Debug.Log("lastVel:" + lastVel);
        Debug.Log("normalVec:" + normalVec.normalized);
        Debug.Log("dir:" + dir);
    }
}
