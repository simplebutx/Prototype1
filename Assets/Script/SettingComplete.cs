using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingComplete : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;

    public void EndSetting()//세팅 끝나면 슬롯 스프라이트 비활성 및 드래그 포인트 활성
    {
        slot.SetActive(false);
        dragPoint.SetActive(true);
    }
}
