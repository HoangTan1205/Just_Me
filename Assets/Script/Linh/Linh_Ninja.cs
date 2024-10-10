using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_Ninja : Linh_Manager
{
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float move = 250f;

    [SerializeField] private Animator ani;
    [SerializeField] private float TamDanh = 5f;
    [SerializeField] private Transform DoKC;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private GameObject Shuriken;
    [SerializeField] private Transform ViTriBanDan;
    void Update()
    {
        Move(Vector2.right, move, rig);

        DetectEnemies(DoKC, TamDanh, enemyLayer, isAttacking);

        if (DetectEnemies(DoKC, TamDanh, enemyLayer, isAttacking))
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
        ani.SetBool("Atk_Xa", true);



    }
    void Run()
    {
        move = 250f;
        ani.SetBool("Atk_Gan", false);
        ani.SetBool("Atk_Xa", false);

    }
    void BanDan()
    {
        GameObject Dan = Instantiate(Shuriken, ViTriBanDan.position, Quaternion.identity);
    }

}
