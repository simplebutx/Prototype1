using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DropMonster : MonoBehaviour, IMonsterStat
{
    public MonsterStat monsterStat = new MonsterStat();
    public TMP_InputField inputVal;
    public void UpdateHpStat()//��ǲ�ڽ����� ���� hp ��������ִ� �Լ� MonsterHPInput�� OnEndEdit���� 
    {
        if (float.TryParse(inputVal.text.Trim(), out float val))
        {
            monsterStat.hp = val;
            monsterStat.maxHp = val;
            Debug.Log("Converted value: " + val);
        }
        else
        {
            Debug.Log("Invalid MonsterHp input!");
        }
    }
    public MonsterStat ReturnMonsterStat()
    {
        return monsterStat;
    }
}
