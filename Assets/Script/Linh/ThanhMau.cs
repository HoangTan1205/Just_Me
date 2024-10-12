using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThanhMau : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        
    }
    public void TakeDamage(float damage)
    {
        float currentHealth = slider.value;
        currentHealth -= damage;  // Trừ sát thương vào máu hiện tại       
        slider.value = currentHealth;  // Cập nhật thanh máu
       
    }
}
