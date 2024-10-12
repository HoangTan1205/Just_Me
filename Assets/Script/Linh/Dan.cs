using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : Linh_Manager
{
    [SerializeField] int ID = 2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float move = 1500f;
    [SerializeField] private float damage;

    void Start()
    {
        Destroy(gameObject, 3f);
        damage = Atk(ID);
    }

    void Update()
    {
        Move(Vector2.right, move, rb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Linh"))
        {
            ThanhMau healthBar = collision.gameObject.GetComponent<ThanhMau>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(damage);  // Gọi hàm trừ máu khi va chạm
            }
            move = 0f;
            Destroy(gameObject,0.05f); 
        }

    }
}
