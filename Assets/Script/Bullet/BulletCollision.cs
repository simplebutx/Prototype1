using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public abstract class BulletCollision : MonoBehaviour
{
    public BulletStat myStat;
    private CountBulletBounce count;
    private BulletCollisionPhysics physics;
    private GameObject damageTextPrefab;
    private GameObject damageTextCopy;
    public GameObject monsterList;//영진 추가
    public float[] percentage = { 0.3f, 0.7f, 1f };
    protected virtual void Start()
    {
        myStat = transform.GetComponent<IBulletStat>().ReturnBulletStat();
        physics = transform.GetComponent<BulletCollisionPhysics>();
        count = new CountBulletBounce(this, myStat.bounce);
        damageTextPrefab = Resources.Load("DamageText") as GameObject;
        monsterList = GameObject.FindWithTag("MonsterList");//하이라키상에 있는 빈 오브젝트를 불러옴
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            if (collision.transform.GetComponent<IMonsterCollision>().UpdateHp(myStat.power))
            {
                OnDestroyMonster(collision);
            }
            else
            {
                OnCollisionMonster(collision);
            }
            if (collision.transform.parent)
            {
                if (collision.transform.parent.Equals(monsterList.transform))//저주받아서 monsterList안에 들어가있는 상태의 몬스터를 때리면 함수 불러옴
                {
                    AdditionalDamage(collision);
                }
            }
        }
        if(physics.CalculatePhysics(collision)) count.AddCount();

    }
    public void HpMinusTextFloating(float val)
    {
        damageTextCopy = Instantiate(damageTextPrefab);
        damageTextCopy.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = val.ToString();
        damageTextCopy.transform.localPosition = transform.position;
    }
    public abstract void OnActivateSkill();
    public abstract void OnDestroyMonster(Collision2D collision);
    public abstract void OnCollisionMonster(Collision2D collision);

    public void AdditionalDamage(Collision2D collision)
    {
        if (monsterList.transform.childCount > 1)   //2개 이상 저주받은 몬스터가 있을 떄
        {
            for (int i = 0; i < monsterList.transform.childCount; i++)
            {
                GameObject mon = monsterList.transform.GetChild(i).gameObject;
                if (mon.GetComponent<Monster>().cursed) //한번더 검사하는 이유는 턴이 한번 진행돼야 cursed가 true가 되기 때문에
                {
                    Debug.Log(3);
                    if (!mon.Equals(collision.gameObject))  //충돌한 몬스터와 다른 저주 몬스터
                    {              
                        Debug.Log(4);
                        bool b = mon.GetComponent<IMonsterCollision>().UpdateHp(myStat.power * percentage[myStat.star - 1]);  //인덱스 값을 cursebullet의 스타와 바꿔야함
                    }
                }
            }
        }
    }
}
public class CountBulletBounce {
    public int count;
    public int skillCount;
    private BulletCollision bulletCollision;
    public CountBulletBounce(BulletCollision bulletCollision, int skillCount)
    {
        this.bulletCollision = bulletCollision;
        this.skillCount = skillCount;
        count = 0;
    }
    public void CheckCount()
    {
        if (count % skillCount == 0) bulletCollision.OnActivateSkill();
    }
    public void AddCount()
    {
        count++;
        CheckCount();
    }
}