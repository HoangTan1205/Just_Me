using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanTopdown : MonoBehaviour
{
    public float speed = 10f; // Tốc độ bay của viên đạn
    private Transform target; // Vị trí của kẻ thù
    public float maxLifetime = 5f;
    public int damage = 1 ;
    private void Start()
    {
        Destroy(gameObject, maxLifetime);
    }
    public void SetTarget(Transform enemyTarget)
    {
        target = enemyTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }
        Vector3 direction = (target.parent.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.parent.position) < 0.1f)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    

}