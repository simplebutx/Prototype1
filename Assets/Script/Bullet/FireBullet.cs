using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
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
