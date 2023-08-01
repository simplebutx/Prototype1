using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletCollision : BulletCollision
{
    private BulletCollision bulletCollision;
    public BombBullet bombBulletScript { get; protected set; }

    CountBulletBounce bombCount;
    protected override void Start() 
    {
        base.Start();
        bombBulletScript = transform.GetComponent<BombBullet>();
    }

    public override void OnActivateSkill()
    {
        Debug.Log("Ffffffffff");
    }
    public override void OnDestroyMonster(Collision2D collision)
    {
        
    }
    public override void OnCollisionMonster(Collision2D collision)
    {
        bombCount.AddCount();
    }
}

