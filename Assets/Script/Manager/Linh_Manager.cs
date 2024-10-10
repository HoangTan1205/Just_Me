using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Linh_Manager : MonoBehaviour
{
    
    // Hàm di chuyển
    public virtual void Move(Vector2 direction, float moveSpeed, Rigidbody2D rig)
    {
        Vector3 move = new Vector3(direction.x, direction.y,0) * moveSpeed * Time.deltaTime;
        rig.velocity = move;
    }

    public virtual bool DetectEnemies( Transform NoiBD, float l_TamDanh , LayerMask E_Layer, bool tanCong = false)
    {
        RaycastHit2D hit = Physics2D.Raycast(NoiBD.position, Vector2.right, l_TamDanh, E_Layer);
        Vector2 rayOrigin = NoiBD.position;
        Vector2 rayDirection = Vector2.right * l_TamDanh;
        Color rayColor = hit.collider != null ? Color.red : Color.green; 
        Debug.DrawLine(rayOrigin, rayOrigin + rayDirection, rayColor);
        if (hit.collider != null)
        {
            tanCong = true;
        }
        else
        {
            tanCong = false;
        }
        return tanCong;
    }
    public virtual void ThanhMau( float maxHealth , float currentHealth, Slider healthBarSlider )
    {
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
    }

    public interface IDamageable
    {
        void TrungDon(float damage);
    }



}
