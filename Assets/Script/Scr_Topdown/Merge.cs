using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public GameObject mergedPrefab; 
    public float mergeDistance = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Merges(other.gameObject);
        // Kiểm tra xem đối tượng có thể hợp nhất không
        if (other.CompareTag("Mergeable"))
        {
            float distance = Vector3.Distance(transform.parent.position, other.gameObject.transform.position);
            if (distance < mergeDistance)
            {
                Merges(other.gameObject);
            }
            
        }
    }

    public void Merges(GameObject other)
    {
        // Tạo đối tượng mới từ prefab
        Instantiate(mergedPrefab, transform.position, Quaternion.identity);

        // Xóa hai đối tượng cũ
        Destroy(gameObject);
        Destroy(other);
    }
}