using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : Linh_Manager
{
    public Rigidbody2D rb;
    private float move = 1000f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        Move(Vector2.right, move, rb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject,0.2f); 
        }
    }
}
