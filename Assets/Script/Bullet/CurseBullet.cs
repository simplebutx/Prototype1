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
            monster.myState = StateSystem.State.ISCURSED;
            if (monster.myCurseTurn.Equals(0))  // ó�� ���ֱ������� ���ݴ��� ���� ���
            {
                monster.myCurseTurn = DataController.instance.gameData.turn;
            }
        }
    }

}
