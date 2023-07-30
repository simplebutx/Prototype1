using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class BuffSystem:MonoBehaviour
{
    public UnityEvent events = new UnityEvent();//이벤트에 저주구슬기능넣기
    public List<BuffMonsters>monsters = new List<BuffMonsters>();
    public List<GameObject> orgMonsters = new List<GameObject>();
    public static BuffSystem instance = null;
    public int index = 0;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public float firedamage = 0;
    public void Collided(int turn,Monster target,float power)//콜리션 발생시, FireBullet 스크립트에서 사용
    {
        BuffMonsters bf = new BuffMonsters(this,turn);
        firedamage = power;
        monsters.Add(bf);
        orgMonsters.Add(target.gameObject);
    }
    public void Fire()
    {
        orgMonsters[index].GetComponent<IMonsterCollision>().UpdateHp(firedamage);
    }
    public void Ice()
    {

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
            bs.orgMonsters.RemoveAt(bs.monsters.IndexOf(this));
            bs.monsters.Remove(this);
        }
    }
    public void Progress(int i)
    {
        count--;
        bs.index = i;      //turncheck에서 리스트 내 삭제가 일어날 경우 인덱스가 바뀌어 지금 문제
        bs.events.Invoke();     //(턴이 끝나고 리스트에서 삭제된 몬스터 아래 몬스터들은 한턴 늦게 도트데미지 발동중)
        TurnCheck();
    }
}
