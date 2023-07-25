using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    private BuffSystem buff;
    protected override void Start()
    {
       buff=transform.GetComponent<BuffSystem>();
    }
    public void FireMonster(Collision2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        monster.myState = StateSystem.State.BURNING;
        monster.myBurningTurn = 2;
        buff.Collided(2);//2는 턴
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
