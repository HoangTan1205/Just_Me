using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeoTha : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition; // Lưu vị trí ban đầu

    void OnMouseDown()
    {
        // Bắt đầu kéo đối tượng
        isDragging = true;
        originalPosition = transform.position; // Lưu vị trí ban đầu
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        // Kết thúc kéo đối tượng
        isDragging = false;

        // Kiểm tra xem có đối tượng nào ở vị trí này không
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        bool merged = false; // Biến để theo dõi việc hợp nhất

        foreach (Collider2D collider in colliders)
        {
            Merge mergeable = collider.GetComponent<Merge>();
            if (mergeable != null && mergeable.gameObject != gameObject)
            {
                mergeable.Merges(gameObject); // Gọi hàm hợp nhất trong script Mergeable
                merged = true; // Đánh dấu đã hợp nhất
                break; // Dừng lại sau khi hợp nhất
            }
        }

        // Nếu không hợp nhất, đưa đối tượng trở về vị trí ban đầu
        if (!merged)
        {
            transform.position = originalPosition;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            // Cập nhật vị trí đối tượng theo chuột
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Lấy vị trí chuột trong không gian thế giới
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // Thiết lập khoảng cách để có vị trí 2D
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
