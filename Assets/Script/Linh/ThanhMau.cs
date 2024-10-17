using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThanhMau : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] float currentHealth;
    private void Awake()
    {
        currentHealth = slider.value;
        slider = GetComponentInChildren<Slider>();
        
    }
    private void Start()
    {
        
        

    }
    [SerializeField]
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;         
        slider.value = currentHealth;  // Cập nhật thanh máu
       
    }
}
