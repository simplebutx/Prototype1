using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollArea : MonoBehaviour
{
    public RectTransform content; // 스크롤될 컨텐츠 영역
    public ScrollRect scrollRect; // 스크롤뷰 컴포넌트

    private void Start()
    {
        scrollRect.normalizedPosition = new Vector2(0, 1); // 스크롤 위치 초기화 (맨 위로)

        // 스크롤뷰의 컨텐츠 크기 설정
        content.sizeDelta = new Vector2(content.sizeDelta.x, 1000); // 예시로 세로 스크롤 기능 구현
    }
}
