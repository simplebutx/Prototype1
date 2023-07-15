using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct BulletStat
{
    public Vector2 direction;
    public int power;
    public float speed;
}
public enum TYPE
{
    Normal, Fire, Bird, Curse
}

public class Bullet:MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rigidbody=null;

    public BulletStat myStat;
    public TYPE type = TYPE.Normal;


    private void Start()//인스턴스화 하면 캐논에서 받아온 direction으로 발사된다.
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction.normalized * myStat.speed;
        Debug.Log($"{myStat.direction},{myStat.speed}");
    }
  

}

