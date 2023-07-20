using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBullet : Bullet
{
    public GameObject babyBirdPrefab;
    public GameObject babyBirdCopy;
    public List<GameObject> monsters = new List<GameObject>();
    private int babyBirdNum;

    protected override void Start()//몬스터 찾아서 체력순 리스트저장
    {
        babyBirdPrefab = Resources.Load("BirdBabyBullet") as GameObject;
        monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        monsters.Sort(compareHp);
        base.Start();
    }
    public void InstantiateBaby()//새끼소환
    {
        float initX = Random.Range(-1f, 1f);
        float initY = Random.Range(-1f, 1f);

        Vector2 startDir = new Vector2(initX, initY);

        for(int i = 0; i < babyBirdNum; i++)
        {
            babyBirdCopy = Instantiate(babyBirdPrefab, transform.position, Quaternion.identity);
            babyBirdCopy.GetComponent<BirdBabyBullet>().target = monsters[i];
            babyBirdCopy.GetComponent<BirdBabyBullet>().startDir = Quaternion.AngleAxis(360f/babyBirdNum*i, Vector3.forward) * startDir.normalized;
        }
    }
    private int compareHp(GameObject A, GameObject B)
    {
        float aHp = A.GetComponent<IMonsterStat>().ReturnMonsterStat().hp;
        float bHp = B.GetComponent<IMonsterStat>().ReturnMonsterStat().hp;
        return aHp < bHp ? -1 : 1;
    }
    public override void StarClassification()
    {
        if (myStat.star == 1)
        {
            babyBirdNum = 2;
            myStat.power = 3;
        }
        else if (myStat.star == 2)
        {
            babyBirdNum = 6;
            myStat.power = 40;
        }
        else
        {
            babyBirdNum = 10;
            myStat.power = 400;
        }
    }
    public void StartTargeting()
    {
        if (monsters.Count < babyBirdNum) babyBirdNum = monsters.Count;
    }
}
