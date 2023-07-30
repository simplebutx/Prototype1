using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseBulletCollision : BulletCollision
{
    public CurseBullet curseBulletScript { get; protected set; }
    protected override void Start()
    {
        base.Start();
        curseBulletScript = transform.GetComponent<CurseBullet>();
    }
    public override void OnActivateSkill()
    {
        //Debug.Log("OnActivateSkill");
    }
    public override void OnDestroyMonster(Collision2D collision)
    {
        
    }
    public override void OnCollisionMonster(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            curseBulletScript.CurseMonster(collision,monsterList);
        }
    }
}
