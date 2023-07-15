using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            collision.gameObject.GetComponent<Monster>().myState = State.ISCURSED;
        }
    }
}
