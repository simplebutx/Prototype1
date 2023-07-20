﻿using System.Collections;
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
        for (int i = 0; i < tempBullets.Length; i++)
        {
            Destroy(tempBullets[i]);
        }
        GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < tempMonsters.Length; i++)
        {
            Monster monster = tempMonsters[i].GetComponent<Monster>();

            if (monster.myState.Equals(StateSystem.State.BURNING) && monster.myBurningTurn > 0)
            {
                monster.CheckState(monster.myState, fb.myStat.power, monster);
            }
        }
    }
}
