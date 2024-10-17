using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controler : MonoBehaviour
{
    public float moveSpeed = 10f; // Tốc độ di chuyển của camera
    public BoxCollider2D boundaryCollider; // Collider xác định giới hạn di chuyển
    private void Awake()
    {
        
    }

    void Update()
    {
        // Nhận đầu vào từ joystick hoặc phím điều khiển
        float moveX = Input.GetAxis("Horizontal"); // Di chuyển theo trục X

        // Cập nhật vị trí mới của camera
        Vector3 newPosition = transform.position + new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime;

        // Giới hạn vị trí camera trong phạm vi collider
        newPosition.x = Mathf.Clamp(newPosition.x, boundaryCollider.bounds.min.x + boundaryCollider.offset.x,
                                         boundaryCollider.bounds.max.x + boundaryCollider.offset.x);
        newPosition.y = transform.position.y; // Giữ nguyên trục Y (trong 2D)

        // Cập nhật vị trí camera
        transform.position = newPosition;
    }
}
