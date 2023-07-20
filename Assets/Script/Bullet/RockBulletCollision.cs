using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBulletCollision : BulletCollision
{
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
        //Debug.Log("Collision at Monster");
    }
}
