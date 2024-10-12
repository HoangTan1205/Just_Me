using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Linh_Kiem : Linh_Manager
{
    [SerializeField] int ID_Linh = 1;
    [SerializeField] private Rigidbody2D rig ;
    [SerializeField] private Animator ani;

    [SerializeField] private float move ;
    [SerializeField] private float tamDanh ;
    [SerializeField] private float hp_Max ;
      // Máu tối đa của enemy   
    [SerializeField] private float HP_HienCo;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu

    [SerializeField] private Transform DoKC;
    [SerializeField] private LayerMask enemyLayer; 
    [SerializeField] private bool isAttacking = false;



    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        move = MoveSpeed(ID_Linh);
        tamDanh = TamDanh(ID_Linh);
        hp_Max = HP(ID_Linh);

        ThanhMau(hp_Max,HP_HienCo, HP_Slider);
        HP_HienCo = HP_Slider.value;
    }


    void Update()
    {
        Move(Vector2.right, move,rig);
        
        Mau_HienTai();

        if (DetectEnemies(DoKC,Vector2.right, tamDanh, enemyLayer, isAttacking))
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
        move = MoveSpeed(ID_Linh);
        ani.SetBool("Atk", false);
       

    }
    public void Mau_HienTai()
    {
        HP_Slider.value = HP_HienCo;

        if (HP_HienCo <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        move = 0f;
        ani.SetBool("Die",true);
        Destroy(gameObject,3);

    }
}
