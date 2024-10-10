using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Linh_Manager
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float move = 1500f;
    [SerializeField] private float tocDoXoay = 1000f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Rotate(0, 0, tocDoXoay * Time.deltaTime);
        Move(Vector2.right, move, rb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            move = 0f;
            Destroy(gameObject, 0.05f);
        }
    }
}