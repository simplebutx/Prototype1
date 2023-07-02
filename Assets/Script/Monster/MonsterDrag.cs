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
    public void OnBeginDrag(PointerEventData eventData)//�巡�� �� �����ɽ�Ʈ�� ���� UI�� �޾ƿ��� ���� �巡�׿� ������ �����ɽ�Ʈ ��Ȱ��ȭ
    {
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)//�巡���� ��ġ ����
    {
        temp = mainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = temp;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)//���� �巡�� ���� �������� �����ɽ�Ʈ�� ����UI �޾ƿü� ������ �� �ڸ��� ���� ������ ����
        {
            monsterCopy = Instantiate(monsterPrefab, eventData.pointerCurrentRaycast.gameObject.transform.position, Quaternion.identity);
            monsterCopy.transform.GetComponent<Monster>().monsterStat = transform.GetComponent<IMonsterStat>().ReturnMonsterStat();
        }
        transform.localPosition = originPos;
        image.raycastTarget = true;//���ư��� �����ɽ�Ʈ �ٽ� Ȱ��ȭ
    }
}
