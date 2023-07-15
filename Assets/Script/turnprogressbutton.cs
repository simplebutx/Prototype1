using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class turnprogressbutton : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;
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
        for (int i = 0; i < tempMonsters.Length; i++)
        {
            Monster monster = tempMonsters[i].GetComponent<Monster>();
            if (monster.myState.Equals(State.BURNING)&&monster.myBurningTurn>0)
            {
                tempMonsters[i].GetComponent<IMonsterCollision>().UpdateHp(4);
            }
        }
    }
}
