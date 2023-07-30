using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CurseBullet : Bullet
{
    public bool isFirstHit = false;
    public float[] percentage = { 0.3f, 0.7f, 1f };
    private int index = 0;

    public void CurseMonster(Collision2D collision,GameObject monsterList)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        GameObject mark = Instantiate(Resources.Load("LYJ/Cursed") as GameObject, monster.transform.localPosition, monster.transform.localRotation);
        mark.transform.SetParent(monster.transform);
        if (!monster.cursed)
        {
            monster.transform.SetParent(monsterList.transform);             //저주받은 몬스터를 씬에 있는 Monsters 리스트에 추가
        }
    }
    
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 10;
            index = 0;
        }
        else if (myStat.star == 2)
        {
            myStat.power = 100;
            index = 1;
        }
        else
        {
            myStat.power = 1000;
            index = 2;
        }
    }

}
