using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DropMonster : MonoBehaviour, IMonsterStat
{
    public MonsterStat monsterStat = new MonsterStat();
    public TMP_InputField inputVal;
    public void UpdateHpStat()//인풋박스에서 받은 hp 적용시켜주는 함수 MonsterHPInput의 OnEndEdit참조 
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
