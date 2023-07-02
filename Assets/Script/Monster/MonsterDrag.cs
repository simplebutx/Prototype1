using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 originPos = new Vector2();
    private Vector2 temp = new Vector2();
    private Image image;
    public Camera mainCamera;
    public GameObject monsterPrefab;
    public GameObject monsterCopy;
    private void Awake()
    {
        originPos = transform.localPosition;
        image = transform.GetComponent<Image>();
        monsterPrefab = Resources.Load("Monster") as GameObject;
    }
    public void OnBeginDrag(PointerEventData eventData)//드래그 후 레이케스트로 슬롯 UI를 받아오기 위해 드래그용 몬스터의 레이케스트 비활성화
    {
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)//드래그중 위치 변경
    {
        temp = mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = temp;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)//만약 드래그 끝난 시점에서 레이케스트로 슬롯UI 받아올수 있으면 그 자리에 몬스터 프리팹 생성
        {
            monsterCopy = Instantiate(monsterPrefab, eventData.pointerCurrentRaycast.gameObject.transform.position, Quaternion.identity);
            monsterCopy.transform.GetComponent<Monster>().monsterStat = transform.GetComponent<IMonsterStat>().ReturnMonsterStat();
        }
        transform.localPosition = originPos;
        image.raycastTarget = true;//돌아가고 레이케스트 다시 활성화
    }
}
