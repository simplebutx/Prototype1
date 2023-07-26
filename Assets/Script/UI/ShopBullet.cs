using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ShopBullet : MonoBehaviour, IPointerClickHandler
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
    public void OnPointerClick(PointerEventData eventData)//몬스터 클릭시 x버튼 나타남
    {
        inventorySlot.bulletAdd(bulletInfo);
    }
}
[Serializable]
public struct BulletUI
{
    public int star;
    public Material color;
    public string bulletType;
}