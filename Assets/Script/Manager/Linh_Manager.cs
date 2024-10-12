using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Linh_Manager : MonoBehaviour
{
    public Scr_Table_Object data;
    // Hàm di chuyển
    public virtual void Move(Vector2 direction, float moveSpeed, Rigidbody2D rig)
    {
        Vector3 move = new Vector3(direction.x, direction.y,0) * moveSpeed * Time.deltaTime;
        rig.velocity = move;
    }

    public virtual bool DetectEnemies( Transform NoiBD, Vector2 huong, float l_TamDanh , LayerMask E_Layer, bool tanCong = false)
    {
        RaycastHit2D hit = Physics2D.Raycast(NoiBD.position, huong, l_TamDanh, E_Layer);
        Vector2 rayOrigin = NoiBD.position;
        Vector2 rayDirection = huong * l_TamDanh;
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
        healthBarSlider.maxValue = maxHealth;
        currentHealth = maxHealth;      
        healthBarSlider.value = currentHealth;
    }
    public interface IDamageable
    {
        void TrungDon(float damage);
    }

    public float HP(int id)
    {
        var tim = data.tableObjects.FirstOrDefault(s => s.Id == id);
        return tim.Hp;
    }
    public float Atk(int id)
    {
        var tim = data.tableObjects.FirstOrDefault(s => s.Id == id);
        return tim.Dmg;

    }

    public float MoveSpeed(int id)
    {
        var tim = data.tableObjects.FirstOrDefault(s => s.Id == id);
        return tim.TocDoChay;
    }

    public float AtkSpeed(int id)
    {
        var tim = data.tableObjects.FirstOrDefault(s => s.Id == id);
        return tim.TocDoBan;

    }
    public float TamDanh(int id)
    {
        var tim = data.tableObjects.FirstOrDefault(s => s.Id == id);
        return tim.TamBan;

    }



}
