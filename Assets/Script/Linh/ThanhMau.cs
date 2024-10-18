using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThanhMau : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
               
    }
    private void Start()
    {
        
    }
    [SerializeField]
    public void TakeDamage(float damage)
    {
        slider = GetComponentInChildren<Slider>();
        float currentHealth = slider.value;

        currentHealth -= damage;         
        slider.value = currentHealth;  // Cập nhật thanh máu

        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
