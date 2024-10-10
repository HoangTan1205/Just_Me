using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_Hiep_Si : Linh_Manager
{
    [SerializeField] private Rigidbody2D rig ;
    [SerializeField] private float move = 250f;
    [SerializeField] private Transform DoKC;


    [SerializeField] private float TamDanh = 0.7f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private Animator ani;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move(Vector2.right, move, rig);

        if (DetectEnemies(DoKC,TamDanh, enemyLayer, isAttacking))
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
}
