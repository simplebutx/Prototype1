using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class BuffSystem:MonoBehaviour
{
    TurnManager turnManager;

    public Burns burns;

    private void Start()
    {
        burns = null;//객체 널 초기화 필수!!
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }


    public void Burn()//버프 시작(총알이 부딫혔을때) 버프에 맞는 객체를 생성해주면 된다. 버프는 갱신되어야 하므로 기존의 버프 존재시 널로 비워주기
    {
        if(burns != null) burns.EndBuff();
        burns = new Burns(turnManager, gameObject, this);
    }
    public void EndBurn()//버프 끝내기
    {
        burns = null;
    }
}
[Serializable]
public class Burns//불태우기 일으키는 객체
{
    public GameObject monster;
    public BuffSystem buffSystem;
    public TurnManager turn;
    public int count = 3;
    public Burns(TurnManager turn, GameObject monster, BuffSystem buffSystem)
        //생성자 변수 할당 및 턴매니저에 있는 턴진행 이벤트에 함수 할당 그리고 버프 할당 되자마자 발생해야하는 것들 추가
    {
        this.turn = turn;
        this.monster = monster;
        this.buffSystem = buffSystem;
        turn.OnTurnProgress.AddListener(Progress);
        monster.GetComponent<SpriteRenderer>().material = Resources.Load("Materials/BurningColor") as Material;
    }
    public void Progress()//턴 진행시 발생하는 내용(버프내용)
    {
        monster.GetComponent<IMonsterCollision>().UpdateHp(30);
        if (--count <= 0) EndBuff();
    }
    public void EndBuff()//카운트 0 되면 발생하는 버프 종료 만약 원래 상태로 되돌려야 하는 내용이 필요할 경우 코드를 추가하면 된다.
    {
        turn.OnTurnProgress.RemoveListener(Progress);
        monster.GetComponent<SpriteRenderer>().material = Resources.Load("Materials/MonsterDefaultColor") as Material;
        buffSystem.EndBurn(); 
    }
}