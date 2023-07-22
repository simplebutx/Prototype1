using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBabyBullet : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public GameObject target;
    public Vector2 startDir = new Vector2();
    public Vector2 dir = new Vector2();
    public float power = 20f;
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = startDir*20f;
    }
    void Update()
    {
        dir = (target.transform.position - transform.position);
        if (Vector3.Cross(dir, rigidbody.velocity).z < 0)
        {
            dir = Quaternion.AngleAxis(12f, Vector3.forward) * rigidbody.velocity;
        }
        else
        {
            dir = Quaternion.AngleAxis(-12f, Vector3.forward) * rigidbody.velocity;
        }
        rigidbody.velocity = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            collision.GetComponent<Monster>().UpdateHp(power);
            Destroy(gameObject);
        }
    }
}
