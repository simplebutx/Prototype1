using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class turnprogressbutton : MonoBehaviour
{
    public GameObject slot;
    public GameObject dragPoint;
    public void OnClick()
    {
        slot.SetActive(true);
        dragPoint.SetActive(true);
        GameObject[] tempMonsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject[] tempBullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < tempMonsters.Length; i++)
        {
            Destroy(tempMonsters[i]);
        }
        for (int i = 0; i < tempBullets.Length; i++)
        {
            Destroy(tempBullets[i]);
        }
    }
}
