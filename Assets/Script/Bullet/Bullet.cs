using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rigidbody;
    public float speed;
    public float power;
    private void Start()//�ν��Ͻ�ȭ �ϸ� ĳ���� �޾ƿ� direction���� �߻�ȴ�.
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction.normalized * speed;
    }
}
