using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    [SerializeField] public float smoothness= 0.001f;

    private float minY = -18f; // 카메라 Y 좌표의 최소 값
    private float maxY = 1; // 카메라 Y 좌표의 최대 값

    void Update()
    {
        // 마우스 왼쪽 버튼을 누르면 드래그를 시작합니다.
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // 마우스 왼쪽 버튼을 누른 채로 드래그하면 카메라를 이동시킵니다.
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 moveDirection = (currentPosition - dragOrigin) * smoothness;

            // 카메라 이동 방향을 상대적인 월드 좌표로 변환합니다.
            moveDirection.x = 0;

            // 카메라를 이동시킵니다.
            Vector3 newPosition = transform.position - moveDirection;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;

        }
    }
}
