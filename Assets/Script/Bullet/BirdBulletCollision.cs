using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBulletCollision : BulletCollision
{
    public BirdBullet birdBulletScript { get; protected set; }
    protected override void Start()
    {
        base.Start();
        birdBulletScript = transform.GetComponent<BirdBullet>();
    }
    public override void OnActivateSkill()
    {
        //Debug.Log("OnActivateSkill");
    }
    public override void OnDestroyMonster(Collision2D collision)
    {
        birdBulletScript.monsters.Remove(collision.gameObject);
        birdBulletScript.StartTargeting();
        birdBulletScript.InstantiateBaby();
    }
    public override void OnCollisionMonster(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
