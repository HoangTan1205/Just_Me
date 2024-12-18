using System.Collections.Generic;
using UnityEngine;

public class Merge_Grid : MonoBehaviour
{
    public GameObject newObjectPrefab;
    private Dictionary<Vector2Int, GameObject> gridObjects = new Dictionary<Vector2Int, GameObject>();
    private int gridSize = 1; // Khoảng cách giữa các ô trong grid

    // Hàm này di chuyển đối tượng đến ô mới và kiểm tra xung quanh
    public void MoveObject(GameObject obj, Vector2 newPosition)
    {
        Vector2Int gridPos = WorldToGridPosition(newPosition);

        if (gridObjects.ContainsKey(gridPos))
            return; // Ô này đã có đối tượng

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        int adjacentCount = 0;

        foreach (var dir in directions)
        {
            if (gridObjects.ContainsKey(gridPos + dir))
                adjacentCount++;
        }

        // Nếu có đủ 2 đối tượng liền kề
        if (adjacentCount >= 2)
        {
            Instantiate(newObjectPrefab, GridToWorldPosition(gridPos), Quaternion.identity);
            // Xóa hoặc ẩn các đối tượng cũ tại các vị trí liền kề
            foreach (var dir in directions)
            {
                if (gridObjects.ContainsKey(gridPos + dir))
                {
                    Destroy(gridObjects[gridPos + dir]);
                    gridObjects.Remove(gridPos + dir);
                }
            }
        }
        else
        {
            // Cập nhật vị trí của đối tượng trên lưới
            Vector2Int oldPos = WorldToGridPosition(obj.transform.position);
            if (gridObjects.ContainsKey(oldPos)) gridObjects.Remove(oldPos);

            obj.transform.position = GridToWorldPosition(gridPos);
            gridObjects[gridPos] = obj;
        }
    }

    private Vector2Int WorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int(Mathf.RoundToInt(worldPosition.x / gridSize), Mathf.RoundToInt(worldPosition.y / gridSize));
    }

    private Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x * gridSize, gridPosition.y * gridSize);
    }
}

