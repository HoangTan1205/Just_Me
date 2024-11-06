using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public GameObject mergedPrefab; 
    public float mergeRadius = 0.2f;

    public void CheckForMerge()
    {
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, mergeRadius);
        List<Merge> mergeableObjects = new List<Merge>();

        foreach (Collider2D collider in nearbyObjects)
        {
            Merge mergeable = collider.GetComponent<Merge>();
            if (mergeable != null && mergeable != this)
            {
                mergeableObjects.Add(mergeable);
            }
        }

        if (mergeableObjects.Count >= 2) // Tổng cộng 3 đối tượng
        {
            PerformMerge(mergeableObjects);
        }
    }

    private void PerformMerge(List<Merge> mergeables)
    {
        // Tạo vị trí trung bình để sinh ra đối tượng hợp nhất
        Vector3 spawnPosition = ( mergeables[0].transform.position + mergeables[1].transform.position) / 3;

        // Sinh đối tượng hợp nhất
        Instantiate(mergedPrefab, spawnPosition, Quaternion.identity);

        // Xóa tất cả các đối tượng đã hợp nhất, bao gồm cả đối tượng này
        Destroy(gameObject);
        foreach (var mergeable in mergeables)
        {
            Destroy(mergeable.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, mergeRadius);
    }

}