using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carot : Linh_Manager
{
    [SerializeField] int ID = 2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float move = 1000f;
    [SerializeField] private float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
        damage = Atk(ID);
    }

    void Update()
    {
        Move(Vector2.left, move, rb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Linh"))
        {
            move = 0f;
            Destroy(gameObject, 0.05f);
            ThanhMau healthBar = collision.gameObject.GetComponentInChildren<ThanhMau>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(damage);  // Gọi hàm trừ máu khi va chạm
            }
            
        }

    }
}
