using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBullet : MonoBehaviour
{
    public GameObject choosedBullet;

    public Button Btn_Bullet1;
    public Button Btn_Bullet2;
    public Button Btn_Bullet3;
    public Button Btn_Bullet4;

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;

    public void Start()
    {
        Btn_Bullet1.onClick.AddListener(Bullet1Clicked);
        Btn_Bullet2.onClick.AddListener(Bullet2Clicked);
        Btn_Bullet3.onClick.AddListener(Bullet3Clicked);
        Btn_Bullet4.onClick.AddListener(Bullet4Clicked);
    }
    public void Bullet1Clicked()
    {
        choosedBullet = Bullet1;
    }

    public void Bullet2Clicked()
    {
        choosedBullet = Bullet2;
    }

    public void Bullet3Clicked()
    {
        choosedBullet = Bullet3;
    }

    public void Bullet4Clicked()
    {
        choosedBullet = Bullet4;
    }

    public void Update()
    {
        Debug.Log(choosedBullet);
    }
}
