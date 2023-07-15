using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class turnprogressbutton : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;
    public FireBullet fb;
    public void OnClick()
    {
        slot.SetActive(true);
        dragPoint.SetActive(true);
        GameObject[] tempBullets = GameObject.FindGameObjectsWithTag("Bullet");
        GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < tempBullets.Length; i++)
        {
            Destroy(tempBullets[i]);
        }
        for (int i = 0; i < tempMonsters.Length; i++)   // 턴이 종료됐을때 화염데미지
        {
            Monster monster = tempMonsters[i].GetComponent<Monster>();

            if (monster.myState.Equals(State.BURNING)&&monster.myBurningTurn>0)
            {
                IMonsterCollision imc = tempMonsters[i].GetComponent<IMonsterCollision>();
                imc.CheckFire();
                imc.UpdateHp(fb.myStat.power) ;
            }
        }
    }
}
