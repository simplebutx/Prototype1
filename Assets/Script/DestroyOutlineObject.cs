using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutlineObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//�Ѿ��� �ٴ����� �������� �ı���Ŵ
    {
        Destroy(collision.gameObject);
    }
}
