using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : Bullet
{
    public GameObject rockBulletPrefab;
    public GameObject rockBulletCopy;
    protected override void Start()
    {
        base.Start();
        rockBulletPrefab = Resources.Load("RockBullet") as GameObject;
    }

    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            myStat.power = 10f;
        }
        else if (myStat.star == 2)
        {
            myStat.power = 100f;
        }
        else
        {
            myStat.power = 100f;
        }
    }
}
