using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletCollision : BulletCollision
{
    public FireBullet fireBulletScript { get; protected set; }
    protected override void Start()
    {
        base.Start();
        fireBulletScript = transform.GetComponent<FireBullet>();
    }
    public override void OnActivateSkill()
    {
        //Debug.Log("OnActivateSkill");
    }
    public override void OnDestroyMonster(Collision2D collision)
    {
        //Debug.Log("Destroyed Monster");
    }
    public override void OnCollisionMonster(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            fireBulletScript.FireMonster(collision);
        }
        HpMinusTextFloating(myStat.power);
    }
}
