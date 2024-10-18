using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tho : Linh_Manager
{
    [SerializeField] int ID_E = 2;
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
    [SerializeField] private GameObject VienDan;
    [SerializeField] private Transform ViTriBanDan;
    [SerializeField] private bool live = true;


    void Awake()
    {
        
    }

    private void Start()
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
        move = MoveSpeed(ID_E);
        ani.SetBool("Atk", false);


    }


    void Die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        move = 0f;
        ani.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
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

    void BanDan()
    {
        GameObject Dan = Instantiate(VienDan, ViTriBanDan.position, Quaternion.identity);
    }
}
