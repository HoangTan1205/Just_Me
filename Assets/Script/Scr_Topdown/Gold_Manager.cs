using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold_Manager : MonoBehaviour
{
    public static Gold_Manager instance; // Đối tượng singleton
    public TextMeshProUGUI gold;
    public int goldAmount = 0; // Số lượng vàng hiện tại

    private void Update()
    {
        gold.text = goldAmount.ToString();
    }
    private void Awake()
    {
        // Kiểm tra xem có đối tượng GoldManager nào khác không
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại đối tượng này giữa các scene
        }
        else
        {
            Destroy(gameObject); // Xóa đối tượng trùng lặp
        }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        
    }
}
