using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public Collider2D myCol;
    public MouseUp slotUIScript;
    private void Start()
    {
        slotUIScript.onDropEvent.AddListener(EnableCollider);
    }
    public void EnableCollider()
    {
        myCol.enabled = true;
    }
    public void DisableCollider()
    {
        myCol.enabled = false;
    }
}
