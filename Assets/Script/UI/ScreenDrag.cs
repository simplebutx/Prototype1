using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    [SerializeField] public float smoothness= 0.001f;

    private float minY = -18f; // ī�޶� Y ��ǥ�� �ּ� ��
    private float maxY = 1; // ī�޶� Y ��ǥ�� �ִ� ��

    void Update()
    {
        // ���콺 ���� ��ư�� ������ �巡�׸� �����մϴ�.
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // ���콺 ���� ��ư�� ���� ä�� �巡���ϸ� ī�޶� �̵���ŵ�ϴ�.
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 moveDirection = (currentPosition - dragOrigin) * smoothness;

            // ī�޶� �̵� ������ ������� ���� ��ǥ�� ��ȯ�մϴ�.
            moveDirection.x = 0;

            // ī�޶� �̵���ŵ�ϴ�.
            Vector3 newPosition = transform.position - moveDirection;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;

        }
    }
}
