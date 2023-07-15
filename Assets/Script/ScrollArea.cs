using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollArea : MonoBehaviour
{
    public RectTransform content; // ��ũ�ѵ� ������ ����
    public ScrollRect scrollRect; // ��ũ�Ѻ� ������Ʈ

    private void Start()
    {
        scrollRect.normalizedPosition = new Vector2(0, 1); // ��ũ�� ��ġ �ʱ�ȭ (�� ����)

        // ��ũ�Ѻ��� ������ ũ�� ����
        content.sizeDelta = new Vector2(content.sizeDelta.x, 1000); // ���÷� ���� ��ũ�� ��� ����
    }
}
