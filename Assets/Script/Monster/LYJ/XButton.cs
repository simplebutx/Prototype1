using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public BoxCollider2D boxCollider;
   public void OnClick()
    {
        if (isActiveAndEnabled)
        {
            boxCollider.enabled = false;
            Destroy(transform.parent.transform.parent.gameObject);
        }
    }
}
