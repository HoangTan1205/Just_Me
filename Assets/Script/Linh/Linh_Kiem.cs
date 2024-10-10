using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Linh_Kiem : Linh_Manager
{
    [SerializeField] private Rigidbody2D rig ;
    [SerializeField] private float move = 250f;

    [SerializeField] private float TamDanh = 0.95f;
    [SerializeField] private Transform DoKC;
    [SerializeField] private LayerMask enemyLayer; 
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private Animator ani;

    [SerializeField] private float HP_Max = 50f;      // Máu tối đa của enemy   
    [SerializeField] private float HP_HienTai;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        Move(Vector2.right, move,rig);
        ThanhMau(HP_Max, HP_HienTai,  HP_Slider );


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
    public void TrungDon(float damage)
    {
        Debug.Log("TrungDon "+ damage);
        HP_HienTai -= damage;
        HP_Slider.value = HP_HienTai;
        

        if (HP_HienTai <= 0)
        {
            Die();
        }
    }

    void Die()
    {        
        ani.SetBool("Die",true);
        Destroy(gameObject,0.5f);

    }
}
