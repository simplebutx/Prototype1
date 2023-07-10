using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public interface IMonsterCollision//총알과 충돌시 hp업데이트 인터페이스
{
    public void UpdateHp(float damage);
}
public class Monster : MonoBehaviour, IMonsterStat, IMonsterCollision,IPointerClickHandler
{
    public MonsterStat monsterStat = new MonsterStat();
    public UnityEvent onDestroy = new UnityEvent();
    public Slider hpSlider;
    public bool isClicked = false;
    public GameObject xButton;

    private void Start()
    {
        onDestroy.AddListener(DestroySelf);
    }

    public void UpdateHp(float damage)
    {
        monsterStat.hp -= damage;
        if (monsterStat.hp <= 0)
        {
            onDestroy.Invoke();
        }
        hpSlider.value = monsterStat.hp / monsterStat.maxHp ;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public MonsterStat ReturnMonsterStat()
    {
        return monsterStat;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = (isClicked ? false : true);
        xButton.SetActive(isClicked);

    }
}
