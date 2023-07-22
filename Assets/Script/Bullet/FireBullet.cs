using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public void FireMonster(Collision2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        monster.myState = StateSystem.State.BURNING;
        monster.myBurningTurn = 2;
    }
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 3;
        }
        else if (myStat.star == 2)
        {
            myStat.power = 40;
        }
        else
        {
            myStat.power = 400;
        }
    }
}
