using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventorySlot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletCopy;
    public List<GameObject> bulletSlots { get; protected set; } = new List<GameObject>();
    private void Start()
    {
        for(int i = 0;i < transform.childCount; i++)
        {
            bulletSlots.Add(transform.GetChild(i).gameObject);
        }
    }

    public void bulletAdd(BulletUI bulletInfo)
    {
        foreach(GameObject slot in bulletSlots)
        {
            if (slot.transform.childCount == 0)
            {
                bulletCopy = Instantiate(Resources.Load("InventoryBullet") as GameObject, slot.transform);
                bulletCopy.transform.localPosition = Vector3.zero;
                bulletCopy.GetComponent<InventoryBullet>().bulletInfo = bulletInfo;
                break;
            }
        }
    }
}
