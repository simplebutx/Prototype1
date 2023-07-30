using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TurnManager : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;
    public GameObject monsterList;
    public UnityEvent OnTurnProgress;

    public int turn { get; protected set; }
    public void Start()
    {
        turn = 0;
    }
    public void OnClick()   //턴진행 누를시
    {
        //slot.SetActive(true);
        dragPoint.SetActive(true);
        //Curse();
        turn++;
        OnTurnProgress.Invoke();
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
