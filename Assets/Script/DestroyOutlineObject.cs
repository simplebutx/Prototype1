using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutlineObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//ÃÑ¾ËÀÌ ¹Ù´ÚÀ¸·Î ³»·Á¿À¸é ÆÄ±«½ÃÅ´
    {
        Destroy(collision.gameObject);
    }
}
