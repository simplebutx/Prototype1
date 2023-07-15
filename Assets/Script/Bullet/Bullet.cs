using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBulletStat
{
    public BulletStat ReturnBulletStat();
}

public class Bullet:MonoBehaviour, IBulletStat
{
    public Vector2 direction;
    private Rigidbody2D rigidbody=null;
    public BulletStat myStat = new BulletStat();
    private void Start()//인스턴스화 하면 캐논에서 받아온 direction으로 발사된다.
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = myStat.direction.normalized * myStat.speed;
    }

    public BulletStat ReturnBulletStat()
    {
        return myStat;
    }
}

[Serializable]
public class BulletStat
{
    public Vector2 direction;
    public int power;
    public float speed;
}
