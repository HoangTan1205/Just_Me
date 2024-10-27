using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Lv1 : MonoBehaviour, IDamageable
{
    public Transform towerPosition;
    public Transform linhPosition;
    
    private Animator animator;           // Animator để điều khiển các trạng thái animation
    private Vector3 initialPosition;     // Vị trí ban đầu của enemy
    private float nextShootTime;
    public float stopDistance = 0.3f;
    public float detectRange = 10f;
    public int currentHealth;
    public float moveSpeed;
    public int damgeE;
    void Start()
    {
        damgeE = 1;
        moveSpeed = 2;
        currentHealth = 1;
        animator = GetComponent<Animator>();   // Lấy Animator từ enemy
        initialPosition = transform.parent.position;  // Lưu vị trí ban đầu
        GameObject thapChinh = GameObject.FindGameObjectWithTag("Tower");
        towerPosition = thapChinh.GetComponent<Transform>();
    }

    void Update()
    {
        
        FindClosestLinh();
        if (linhPosition == null )
        {
            diChuyenToiMucTieu(towerPosition);
        }

        if (linhPosition != null )
        {
            diChuyenToiMucTieu(linhPosition);
        }
    }

    void FindClosestLinh()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Linh");
        float minDistance = detectRange;
        linhPosition = null;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                linhPosition = enemy.transform;
            }
        }
    }
    void diChuyenToiMucTieu(Transform mucTieuMove)
    {
        float distance = Vector3.Distance(transform.parent.position, mucTieuMove.position);
        CheckMat(mucTieuMove);
        if (distance > stopDistance && currentHealth > 0)
        {
            // Di chuyển về phía quân lính
            Vector3 direction = (mucTieuMove.position - transform.parent.position).normalized;
            transform.parent.position += direction * moveSpeed * Time.deltaTime;
        }
        else if(distance <= stopDistance && currentHealth > 0)
        {        
            IDamageable damageable = mucTieuMove.gameObject.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damgeE);
            }

            
        }
    }
    void CheckMat(Transform mucTieuFlip)
    {

        Vector3 directionToEnemy = mucTieuFlip.position - transform.parent.position;
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        moveSpeed = 0;
        Animator ani = gameObject.GetComponent<Animator>();
        ani.SetTrigger("Die");
        Destroy(transform.parent.gameObject, 0.3f);
    }
}
