using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class GridManager : MonoBehaviour
{
 
    public GameObject enemyPrefab;      // Prefab của kẻ địch
    public List<Transform> spawnPoints; // Danh sách các vị trí ô vuông

    public int enemyCount = 1;
    void Start()
    {
        
        
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (spawnPoints.Count == 0)
            {
                Debug.Log("Full");
                break;
            }// Nếu không còn ô trống, dừng spawn

            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomIndex];

            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Loại bỏ ô vuông khỏi danh sách ô trống sau khi spawn
            spawnPoints.RemoveAt(randomIndex);
        }
    }
}

