using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            monster.myState = State.BURNING;
            monster.myBurningTurn = 2;
        }
    }
}
