using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Linh_Xa_Thu : Linh_Manager
{
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float move = 250f;
    [SerializeField] private Animator ani;
    [SerializeField] private float TamDanh = 5f;
    [SerializeField] private Transform DoKC;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private GameObject VienDan;
    [SerializeField] private Transform ViTriBanDan;

 

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move(Vector2.right, move, rig);

        DetectEnemies(DoKC,TamDanh, enemyLayer, isAttacking);

        if (DetectEnemies(DoKC,TamDanh, enemyLayer, isAttacking)  )
        {
            Attack();
        }
        else
        {
            Run();
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
}
