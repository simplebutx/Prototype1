using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseBullet : Bullet
{
    public bool isFirstHit = false;
    public float[] percentage = { 0.3f, 0.7f, 1f };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            monster.myState = State.ISCURSED;
            if (monster.myCurseTurn.Equals(0))  // ó�� ���ֱ������� ���ݴ��� ���� ���
            {
                monster.myCurseTurn = DataController.instance.gameData.turn;
            }
            CheckingCurse(myStat.power * percentage[0],collision,monster);   
        }
    }
    void CheckingCurse(float additionalDamage,Collision2D collision,Monster monsterScript)
    {
        GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in tempMonsters)
        {
            int turnDiff = DataController.instance.gameData.turn - monsterScript.myCurseTurn;
            //1. �浹�� ���Ͱ� ���ֹ��� �����϶� (Collided monster must be cursed)
            //2. �浹�� ���͸� ������ �ٸ� ���ֹ��� ���͵鿡�Ը� �߰� ������ (Additional damage is not applied to the collided monster)
            //3. ���ָ� ���� ���� �ƴ϶� �����Ϻ��� (is applied after the cursed turn)
            if (monster.GetComponent<Monster>().myState.Equals(State.ISCURSED) && monster.gameObject != collision.gameObject&&turnDiff>0)
            {
                monster.GetComponent<IMonsterCollision>().UpdateHp(additionalDamage);
            }
        }
    }
}
