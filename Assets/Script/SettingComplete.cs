using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingComplete : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;

    public void EndSetting()//���� ������ ���� ��������Ʈ ��Ȱ�� �� �巡�� ����Ʈ Ȱ��
    {
        slot.SetActive(false);
        dragPoint.SetActive(true);
    }
}
