using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IMonsterStat
{
    public MonsterStat ReturnMonsterStat();
}
[Serializable]
public class MonsterStat
{
    public float Hp;
    public float Power;
}
