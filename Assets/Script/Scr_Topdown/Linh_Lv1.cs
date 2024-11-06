using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_Lv1 : MonoBehaviour, IDamageable
{
    public Transform target; // Điểm tham chiếu cho quân lính
    public float detectRange = 3f; // Phạm vi phát hiện
    public float stopDistance = 5f; // Khoảng cách giữ khi tấn công
    public float moveSpeed = 2f;
    public GameObject bulletPrefab;
    public GameObject muzzle;
    public Transform shootPoint;
    public float shootInterval = 1f;
    public int currentHealth;

    private float nextShootTime;
    private bool isDead = false;
    void Start()
    {
        currentHealth = 1;
    }
    void Update()
    {
        if (target == null) FindClosestEnemy();

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            CheckMat();
            //  if (distance > stopDistance)
            //  {
            //      // Di chuyển về phía quân lính
            //      Vector3 direction = (target.position - transform.position).normalized;
            //      transform.position += direction * moveSpeed * Time.deltaTime;
            //  }
            if(distance <= detectRange) 
            {
                // Giữ khoảng cách và bắn
                if (Time.time >= nextShootTime)
                {
                    Shoot();
                    nextShootTime = Time.time + shootInterval;
                }
            }
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = detectRange;
        target = null;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                target = enemy.transform;
            }
        }
    }

    void Shoot()
    {
        Instantiate(muzzle, shootPoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<DanTopdown>().SetTarget(target);

    }
    void CheckMat()
    {
        
        Vector3 directionToEnemy = target.position - transform.parent.position;
        if (directionToEnemy.x < 0 && transform.localScale.x > 0)
        {
            Flip();  // Quay mặt sang trái
        }
        // Nếu kẻ địch ở phía bên phải và nhân vật đang quay mặt sang trái
        else if (directionToEnemy.x > 0 && transform.localScale.x < 0)
        {
            Flip();  // Quay mặt sang phải
        }
    }
    void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        moveSpeed = 0;
        Animator ani = gameObject.GetComponent<Animator>();
        ani.SetTrigger("Die");
        Destroy(transform.parent.gameObject, 0.3f);
    }

}
