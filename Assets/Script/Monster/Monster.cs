using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public interface IMonsterCollision//�Ѿ˰� �浹�� hp������Ʈ �������̽�
{
    public void UpdateHp(float damage);
}
public class Monster : MonoBehaviour, IMonsterStat, IMonsterCollision
{
    public MonsterStat monsterStat = new MonsterStat();
    public UnityEvent onDestroy = new UnityEvent();
    public Slider hpSlider;

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
}
