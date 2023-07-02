using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rigidbody;
    public float speed;
    public float power;
    private void Start()//인스턴스화 하면 캐논에서 받아온 direction으로 발사된다.
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction.normalized * speed;
    }
}
