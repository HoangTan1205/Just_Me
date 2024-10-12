using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Linh_Hiep_Si : Linh_Manager
{
    [SerializeField] private int ID_Linh = 3;
    [SerializeField] private Rigidbody2D rig ;
    [SerializeField] private Transform DoKC;
    [SerializeField] private Animator ani;

    [SerializeField] private float move;
    [SerializeField] private float tamDanh;
    [SerializeField] private float hp_Max;
    // Máu tối đa của enemy   
    [SerializeField] private float HP_HienCo;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
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
        move = 250f;
        ani.SetBool("Atk", false);


    }
}
