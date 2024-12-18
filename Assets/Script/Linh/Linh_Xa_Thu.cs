﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Linh_Xa_Thu : Linh_Manager
{
    [SerializeField] int ID_Linh = 2;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator ani;
    [SerializeField] private Transform DoKC;

    [SerializeField] private float move;
    [SerializeField] private float tamDanh;
    [SerializeField] private float hp_Max;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private GameObject VienDan;
    [SerializeField] private Transform ViTriBanDan;

    [SerializeField] private float HP_HienCo;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu

    [SerializeField] private bool live = true;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        move = MoveSpeed(ID_Linh);
        tamDanh = TamDanh(ID_Linh);
        hp_Max = HP(ID_Linh);

        ThanhMau(hp_Max, HP_HienCo, HP_Slider);
        HP_HienCo = HP_Slider.value;

    }


    void Update()
    {
        Move(Vector2.right, move, rig);

        DetectEnemies(DoKC,Vector2.right, tamDanh, enemyLayer, isAttacking);

        Mau_HienTai();
        if (DetectEnemies(DoKC,Vector2.right, tamDanh, enemyLayer, isAttacking)  )
        {
            if (live)
            {
                Attack();
            }
        }
        else
        {
            if (live)
            {
                Run();
            }
        }


    }
    void Attack()
    {
        move = 0f;
        ani.SetBool("Atk", true);
              

    }
    void Run()
    {
        move = 250f;
        ani.SetBool("Atk", false);

    }
    void BanDan()
    {
        GameObject Dan = Instantiate(VienDan, ViTriBanDan.position, Quaternion.identity);
    }
    void Die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        move = 0f;
        ani.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }
    public void Mau_HienTai()
    {
       
        if (HP_Slider.value <= 0)
        {
            isAttacking = false;
            live = false;
            Die();
        }
    }
}
