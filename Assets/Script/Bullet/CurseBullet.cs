using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseBullet : Bullet
{
    public bool isFirstHit = false;
    public float[] percentage = { 0.3f, 0.7f, 1f };

    public void CurseMonster(Collision2D collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        GameObject mark = Instantiate(Resources.Load("LYJ/Cursed") as GameObject, monster.transform.localPosition, monster.transform.localRotation);
        mark.transform.SetParent(monster.transform);
        monster.myState = StateSystem.State.ISCURSED;
        if (monster.myCurseTurn.Equals(0))
        {
            monster.myCurseTurn = DataController.instance.gameData.turn;
        }
    }
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 10;
        }
        else if (myStat.star == 2)
        {
            myStat.power = 100;
        }
        else
        {
            myStat.power = 1000;
        }
    }

}
