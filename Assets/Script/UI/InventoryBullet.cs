using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBullet : MonoBehaviour
{
    public BulletUI bulletInfo = new BulletUI();
    public InventorySlot inventorySlot;
    private void Start()
    {
        inventorySlot = GameObject.Find("Inventory").transform.Find("Slot").GetComponent<InventorySlot>();
        string path = string.Format("Materials/{0}", bulletInfo.bulletType);
        bulletInfo.color = Resources.Load(path) as Material;
        transform.GetComponent<Image>().material = bulletInfo.color;
    }
}
