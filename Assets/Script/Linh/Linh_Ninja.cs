using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Linh_Ninja : Linh_Manager
{
    [SerializeField] private int ID_Linh=4;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator ani;

    [SerializeField] private float move;
    [SerializeField] private float tamDanh;
    [SerializeField] private float hp_Max;
    // Máu tối đa của enemy   
    [SerializeField] private float HP_HienCo;        // Máu hiện tại của enemy
    [SerializeField] private Slider HP_Slider;     // Slider UI của thanh máu

    [SerializeField] private Transform DoKC;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private GameObject Shuriken;
    [SerializeField] private Transform ViTriBanDan;

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

        DetectEnemies(DoKC, Vector2.right, tamDanh, enemyLayer, isAttacking);

        if (DetectEnemies(DoKC, Vector2.right, tamDanh, enemyLayer, isAttacking))
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
