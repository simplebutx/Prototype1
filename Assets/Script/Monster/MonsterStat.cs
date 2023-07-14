using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IMonsterStat//몬스터 스탯 반환 인터페이스
{
    public MonsterStat ReturnMonsterStat();
}
[Serializable]
public class MonsterStat
{
    public float maxHp;
    public float hp;
    public float power;
}
