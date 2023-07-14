using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

//전체 데이터를 관리하는 스크립트

public class GameData
{
    public int turn = 0;    //턴
    public int lifeCount = 3;
    public int stageNum = 0;    //현재 진행중인 스테이지
    public int gold = 0;    //보유 골드


}
public class DataController : MonoBehaviour
{
    
    public static DataController instance;
    public GameData gameData = new GameData();
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
       else
        {
            Destroy(this.gameObject);   
            return;
        }
        DontDestroyOnLoad(gameObject);

    }
}
