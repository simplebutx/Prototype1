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
    public static Bullet instance;
    public BulletStat myStat;
    public TYPE type = TYPE.Normal;
    SpriteRenderer _spriteRenderer = null;
    private void Awake()
    {
        instance = this;
    }
    private void Start()//인스턴스화 하면 캐논에서 받아온 direction으로 발사된다.
    {
        rigidbody = GetComponent<Rigidbody2D>();
       // myStat.power= BulletShoot.instance.bulletPower;
        //myStat.speed = BulletShoot.instance.bulletSpeed;    //필드 버튼(normal, fire, curse)으로 결정되는 공격력과 속도를 전달
        Debug.Log(myStat.speed);
        rigidbody.velocity = direction.normalized * myStat.speed;
    }
  

}

