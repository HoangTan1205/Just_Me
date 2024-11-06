using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwamEnemy : MonoBehaviour
{

    public GameObject enemyPrefab;      // Prefab của kẻ địch
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public List<Transform> spawnPoints; // Danh sách các vị trí ô vuông

    public int enemyCount = 5;          // Số lượng kẻ địch cần spawn

    void Start()
    {
        
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 vt = new Vector3(spawnPoints[randomIndex].position.x, spawnPoints[randomIndex].position.y + 1.1f, spawnPoints[randomIndex].position.z);
            Instantiate(enemyPrefab, vt, Quaternion.identity);
        }
    }
}
