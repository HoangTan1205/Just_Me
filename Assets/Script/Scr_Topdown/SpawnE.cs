using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của quái
    public Transform[] spawnPoints; // Các vị trí spawn có sẵn
    public int maxEnemies = 25; // Số lượng quái tối đa
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa các lần spawn (4 giây)

    public int currentEnemyCount = 0; // Số lượng quái hiện tại trong scene
    public int demQuai;
    public int gold = 20; // Số vàng người chơi có
    public TextMeshProUGUI text;
    private void Start()
    {
        text.text = ("Gold: " + gold);
        // Bắt đầu coroutine để spawn quái
        StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Kiểm tra nếu số lượng quái chưa đạt tối đa
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
            
            
            yield return new WaitForSeconds(spawnInterval); // Đợi 4 giây trước khi tiếp tục
             
        }
    }

    private void SpawnEnemy()
    {
        // Chọn ngẫu nhiên một vị trí từ spawnPoints
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Tạo quái tại vị trí được chọn
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++; // Tăng số lượng quái hiện tại
        demQuai++;
        // Gắn sự kiện OnDeath cho quái
        enemy.GetComponentInChildren<Enemy_Lv1>().OnDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath()
    {
        currentEnemyCount--; // Giảm số lượng quái khi quái bị tiêu diệt
        gold++; // Cộng vàng cho người chơi
        text.text = ("Gold: " + gold); // In ra số vàng hiện tại
    }
    public void TaoLinh(int vang)
    {
        gold = gold - vang;
        text.text = ("Gold: " + gold);
    }
}
