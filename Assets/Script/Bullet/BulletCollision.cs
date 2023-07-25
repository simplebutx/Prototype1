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
    protected virtual void Start()
    {
        myStat = transform.GetComponent<IBulletStat>().ReturnBulletStat();
        physics = transform.GetComponent<BulletCollisionPhysics>();
        count = new CountBulletBounce(this, myStat.bounce);
        damageTextPrefab = Resources.Load("DamageText") as GameObject;
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