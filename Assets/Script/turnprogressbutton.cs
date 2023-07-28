using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class turnprogressbutton : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;
    public FireBullet fb;
    public BuffSystem buff;
    public GameObject monsterList;
    public void OnClick()   //턴진행 누를시
    {
        slot.SetActive(true);
        dragPoint.SetActive(true);
        Curse();
        if (buff.monsters.Count > 0)
        {
            for(int i = 0; i < buff.monsters.Count; i++)
            {
                buff.monsters[i].Progress(i);
            }
         }
        
    }
    public void Curse()
    {
        Monster[] mons = monsterList.GetComponentsInChildren<Monster>();
        for (int i = 0; i < mons.Length; i++)
        {
            if (!mons[i].cursed) mons[i].cursed = true;
        }
    }

}
