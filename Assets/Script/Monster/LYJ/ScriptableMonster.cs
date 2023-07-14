using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonsterData",menuName ="ScriptableObject/MonsterData",order =int.MaxValue)]
public class ScriptableMonster : ScriptableObject
{
    [SerializeField]
    private string _monsterName;
    public string monsterName
    {
        get
        {
            return _monsterName;
        }
    }
    [SerializeField]
    private float _maxHp;
    public float maxHp
    {
        get
        {
            return _maxHp;
        }
    }
    [SerializeField]
    private int _moveSpeed;
    public int moveSpeed
    {
        get
        {
            return _moveSpeed;
        }
    }
}
