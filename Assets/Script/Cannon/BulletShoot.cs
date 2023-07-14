using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject bulletCopy;
    private Transform dragPoint;
    TYPE type;
    SpriteRenderer spriteRenderer = null;
    Color orgColor = Color.gray;
    Bullet bulletScript;
    public int bulletSpeed=10;
    public int bulletPower=10;
    public static BulletShoot instance=null;
    public bool[] damaged = { false, false };
    private int currentTurn = 0;
    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        dragPoint = transform.Find("DragPoint");
        bulletPrefab = Resources.Load("Bullet") as GameObject;
        spriteRenderer = bulletPrefab.GetComponent<SpriteRenderer>();
        bulletScript = bulletPrefab.GetComponent<Bullet>();
        type = bulletScript.type;
        ChangingBulletStat(TYPE.Normal, Color.black, 10, 10);
    }
    public void InstantiateBullet()//총알 인스턴스화 및 방향 전달
    {
        bulletCopy = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletCopy.GetComponent<Bullet>().direction = dragPoint.position - transform.position;
    }
    public void ChangeType(TYPE t)  //버튼을 누르는 즉시 실행
    {
        if (type.Equals(t))
        {
            return;
        }
        type = t;
        switch (type)
        {
            case TYPE.Normal:
                ChangingBulletStat(TYPE.Normal,Color.black,10,10);
                break;
            case TYPE.Fire:
                ChangingBulletStat(TYPE.Fire, Color.red, 4, 10);
                damaged[0] = false;
                damaged[1] = false;
                currentTurn = DataController.instance.gameData.turn;
                break;
            case TYPE.Bird:
                break;
            case TYPE.Curse:
                ChangingBulletStat(TYPE.Curse, Color.green, 10, 10);
                break;
        }
    }
    void StateProcess() //현재 type에 따라 update문에서 실행됨
    {
        switch (type)   
        {
            case TYPE.Normal:
                break;
            case TYPE.Fire:
                //2 turn dot damage
              /*  if ((DataController.instance.gameData.turn - currentTurn).Equals(1)&&damaged[0].Equals(false))
                {
                    damaged[0] = true;
                }
                if ((DataController.instance.gameData.turn - currentTurn).Equals(2) && damaged[1].Equals(false))
                {
                    damaged[1] = true; 
                }*/
                //몬스터 피 깎이는 스크립트(BulletCollision)에서 이 bool 배열로 
                //2턴동안 턴 종료 후 추가 데미지를 주게 짜려 했는데
                //턴진행이 되면 몬스터가 없는 상태로 만들어서 뭔가 혼란스러움
                //차라리 2초마다 코루틴?
                break;
            case TYPE.Bird:
                break;
            case TYPE.Curse:
                //curse monster
                //몬스터색깔은 BulletCollision.cs에서 함
                //저주걸린 적은 입은 피해량의 30% 70% 100%를 공유한다 <- 필드의 다른 적들과??
                break;
        }
    }
    public void ChangingBulletStat(TYPE t,Color color, int power, int speed)   //색깔, 공격력, 속도 바꿈
    {
        bulletScript.type = t;
        spriteRenderer.color = color;
        bulletPower = power;
        bulletSpeed = speed;
    }
    private void Update()
    {
        StateProcess();
    }

    public void FireButtonOnClick()
    {
        ChangeType(TYPE.Fire);
    }
    public void CurseButtonOnClick()
    {
        ChangeType(TYPE.Curse);
    }
    public void NormalButtonOnClick()
    {
        ChangeType(TYPE.Normal);
    }
}
