using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public interface IMonsterCollision//총알과 충돌시 hp업데이트 인터페이스
{
    public bool UpdateHp(float damage);
}
public class Monster :MonoBehaviour, IMonsterStat, IMonsterCollision,IPointerClickHandler
{
    public MonsterStat monsterStat = new MonsterStat();
    public UnityEvent onDestroy = new UnityEvent();
    public Slider hpSlider;
    public bool isClicked = false;
    public GameObject xButton;
    public bool cursed = false;
    public float percentage = 0.3f;//나중에 1성~3성에 따라 외부에서 가져올 값
    private GameObject damageTextPrefab;
    private GameObject damageTextCopy;
    private void Start()
    {
        onDestroy.AddListener(DestroySelf);
        damageTextPrefab = Resources.Load("DamageText") as GameObject;
    }

    public bool UpdateHp(float damage)
    {
        monsterStat.hp -= damage;
        HpMinusTextFloating(damage);

        if (monsterStat.hp <= 0)
        {
            onDestroy.Invoke();
            return true;
        }
        hpSlider.value = monsterStat.hp / monsterStat.maxHp ;
        return false;
    }
    public void HpMinusTextFloating(float val)
    {
        damageTextCopy = Instantiate(damageTextPrefab);
        damageTextCopy.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = val.ToString();
        damageTextCopy.transform.localPosition = transform.position;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        
    }

    public MonsterStat ReturnMonsterStat()
    {
        return monsterStat;
    }
    public void OnPointerClick(PointerEventData eventData)//몬스터 클릭시 x버튼 나타남
    {
        isClicked = (isClicked ? false : true);
        xButton.SetActive(isClicked);
    }
}
