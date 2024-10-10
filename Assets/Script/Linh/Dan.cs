using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : Linh_Manager
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float move = 1500f;
    [SerializeField] private float damage = 5f;

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
        if (collision.gameObject.CompareTag("Linh"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            
            if (damageable != null)
            {
                Debug.Log("TrungDOn");
                //damageable.TrungDon(damage);
            }
            move = 0f;
            Destroy(gameObject,0.05f); 
        }
    }
}
