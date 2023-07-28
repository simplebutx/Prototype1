using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public void FireMonster(Collision2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        BuffSystem.instance.Collided(2, monster, myStat.power);      
    }
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 4;
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
