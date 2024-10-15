using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zombie : Linh_Manager
{
    [SerializeField] int ID_E = 1;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator ani;

    [SerializeField] private float move;
    [SerializeField] private float tamDanh;
    [SerializeField] private float hp_Max;
    // Máu tối đa của enemy   
    [SerializeField] private float HP_HienCo;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu

    [SerializeField] private Transform DoKC;
    [SerializeField] private LayerMask Linh_Layer;
    [SerializeField] private bool isAttacking = false;



    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        move = MoveSpeed(ID_E);
        tamDanh = TamDanh(ID_E);
        hp_Max = HP(ID_E);

        ThanhMau(hp_Max, HP_HienCo, HP_Slider);
        HP_HienCo = HP_Slider.value;
    }


    void Update()
    {
        Move(Vector2.left, move, rig);

        Mau_HienTai();

        if (DetectEnemies(DoKC, Vector2.left, tamDanh, Linh_Layer, isAttacking))
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
        move = MoveSpeed(ID_E);
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
        ani.SetBool("Die", true);
        Destroy(gameObject, 3);

    }
}
