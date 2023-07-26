using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public interface IMonsterCollision//총알과 충돌시 hp업데이트 인터페이스
{
    public bool UpdateHp(float damage);
    public void CheckingState(StateSystem.State t, float damage, Monster monster);
}
public class Monster : StateSystem, IMonsterStat, IMonsterCollision,IPointerClickHandler
{
    public MonsterStat monsterStat = new MonsterStat();
    public UnityEvent onDestroy = new UnityEvent();
    public Slider hpSlider;
    public bool isClicked = false;
    public GameObject xButton;
    public State myState =State.NORMAL; //영진 추가
    public int myBurningTurn = 2;
    public int myCurseTurn = 0;
    public float percentage = 0.3f;//나중에 1성~3성에 따라 외부에서 가져올 값
    private void Start()
    {
        onDestroy.AddListener(DestroySelf);
    }

    public bool UpdateHp(float damage)
    {
        monsterStat.hp -= damage;

        if (monsterStat.hp <= 0)
        {
            onDestroy.Invoke();
            return true;
        }
        hpSlider.value = monsterStat.hp / monsterStat.maxHp ;
        return false;
    }
    public void CheckingState(StateSystem.State t, float damage, Monster monster)
    {
        if(!t.Equals(State.BURNING))CheckState(t,damage,monster);
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public MonsterStat ReturnMonsterStat()
    {
        return monsterStat;
    }
    public void OnPointerClick(PointerEventData eventData)//몬스터 클릭시 x버튼 나타남
    {
        isClicked = (isClicked ? false : true);
        xButton.SetActive(isClicked);
    }
}
