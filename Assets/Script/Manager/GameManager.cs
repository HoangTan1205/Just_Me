using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Giữ đối tượng không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject);  // Hủy đối tượng mới nếu đã tồn tại một instance
        }
    }

    void Update()
    {
        
    }
}
