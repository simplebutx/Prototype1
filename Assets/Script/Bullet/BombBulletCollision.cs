using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBulletCollision : BulletCollision
{
    public BombBullet bombBulletScript { get; protected set; }
    protected override void Start() 
    {
        base.Start();
        bombBulletScript = transform.GetComponent<BombBullet>();
    }
    public override void OnActivateSkill()
    {
       
    }
    public override void OnDestroyMonster(Collision2D collision)
    {
        
    }
    public override void OnCollisionMonster(Collision2D collision)
    {
        
    }
}
