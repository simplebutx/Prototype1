using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IMonsterStat//���� ���� ��ȯ �������̽�
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
