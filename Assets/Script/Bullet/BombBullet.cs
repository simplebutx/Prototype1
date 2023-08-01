using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : Bullet
{
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 2;
        }
        else if (myStat.star == 2)
        {
            myStat.power = 30;
        }
        else
        {
            myStat.power = 300;
        }
    }
}
