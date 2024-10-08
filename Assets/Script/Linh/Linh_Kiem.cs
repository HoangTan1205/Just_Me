using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Linh_Kiem : Linh_Manager
{
    public float TamDanh = 3f;
    public LayerMask enemyLayer; 
    public bool isAttacking = false;

    private Rigidbody2D rig ;
    public float move = 250f;

    public Animator ani;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move(Vector2.right, move,rig);

        DetectEnemies(TamDanh,enemyLayer,isAttacking);

        if (isAttacking)
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
