
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBulletStat
{
    public BulletStat ReturnBulletStat();
}
public abstract class Bullet:MonoBehaviour, IBulletStat
{
    public Vector2 direction;
    public Rigidbody2D rigidbody=null;
    public BulletStat myStat = new BulletStat();
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = myStat.direction.normalized * myStat.speed;
        StarClassification();
    }
    public BulletStat ReturnBulletStat()
    {
        return myStat;
    }
    public abstract void StarClassification();//별에따른 스탯 적용함수
}

[Serializable]
public class BulletStat
{
    public Vector2 direction;
    public float power;
    public int star;
    public int bounce;
    public float speed;
}
