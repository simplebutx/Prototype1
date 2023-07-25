using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class BuffSystem:MonoBehaviour
{
    public UnityEvent events = new UnityEvent();//이벤트에 저주구슬기능넣기
    public List<BuffMonsters>burned = new List<BuffMonsters>();
    public void Start()
    {
        events.AddListener(EndTurn);
        events.Invoke();
    }
    public void Collided(int turn)//콜리션 발생시
    {
        BuffMonsters bf = new BuffMonsters(this,turn);
        burned.Add(bf);
    }
    public void EndTurn()
    {
        //
    }
}
public class BuffMonsters
{
    public int count;
    BuffSystem bs;
    public BuffMonsters(BuffSystem buffsystem,int turn)
    {
        count = turn;
        this.bs = buffsystem;
    }
    public void TurnCheck()
    {
        if (count.Equals(0))
        {
            bs.burned.Remove(this);
            bs.events.RemoveAllListeners();
        }
    }
    public void Progress()
    {
        count--;
        bs.EndTurn();
        TurnCheck();
    }
}