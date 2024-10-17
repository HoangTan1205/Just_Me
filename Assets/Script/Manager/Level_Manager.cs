using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Scr_Data_Level;

public class Level_Manager : MonoBehaviour
{
    public List<ThongTinLevel> listTT = new List<ThongTinLevel>();
    public Scr_Data_Level data_Level ;
    public GameObject enemyType1;  // Prefab cho loại quái 1
    public GameObject enemyType2;  // Prefab cho loại quái 2
    public GameObject enemyType3;  // Prefab cho loại quái 3
    public GameObject enemyType4;  // Prefab cho loại quái 4

    public Transform spawnPoint;   // Điểm sinh ra quái

    private int currentWaveIndex = 0;
    private void Awake()
    {
        LoadTextLevel("Data_Level");
    }
    void Start()
    {
        // Bắt đầu sinh đợt đầu tiên
        StartCoroutine(SpawnWave());
    }

    public void LoadTextLevel(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');
            ThongTinLevel tt = new ThongTinLevel();       
            tt.Id = Convert.ToInt32(cols[0]);
            tt.Level = Convert.ToInt32(cols[1]);
            tt.Wave = Convert.ToInt32(cols[2]);
            tt.LoaiQuai = Convert.ToInt32(cols[3]);
            tt.SoLuong = Convert.ToInt32(cols[4]);
            listTT.Add(tt);
             
            if(data_Level.List_Data_Level.Count < listTT.Count)
            {
                InforLevel list = new InforLevel(tt.Id, tt.Level, tt.Wave, tt.LoaiQuai, tt.SoLuong);
                data_Level.List_Data_Level.Add(list);
            }
            
        }
    }
    IEnumerator SpawnWave()
    {
        while (currentWaveIndex < data_Level.List_Data_Level.Count)
        {
            InforLevel wave = data_Level.List_Data_Level[currentWaveIndex];

            // Kiểm tra level (nếu có hệ thống level)
            if (wave.Level == GetCurrentLevel())  // Giả sử bạn có hàm để lấy level hiện tại
            {
                // Sinh quái theo số lượng trong đợt này
                for (int i = 0; i < wave.SoLuong; i++)
                {
                    SpawnEnemy(wave.LoaiQuai);
                    yield return new WaitForSeconds(7f);  // Khoảng cách thời gian giữa mỗi lần sinh quái
                }

                // Đợi một khoảng thời gian trước khi sinh đợt tiếp theo
                yield return new WaitForSeconds(0.5f);
            }

            currentWaveIndex++;
        }
    }

    void SpawnEnemy(int enemyType)
    {
        GameObject enemyPrefab = null;

        // Chọn loại quái dựa trên enemyType
        switch (enemyType)
        {
            case 1:
                enemyPrefab = enemyType1;
                break;
            case 2:
                enemyPrefab = enemyType2;
                break;
            case 3:
                enemyPrefab = enemyType3;
                break;
            case 4:
                enemyPrefab = enemyType4;
                break;
            default:
                Debug.LogWarning("Unknown enemy type: " + enemyType);
                break;
        }

        if (enemyPrefab != null)
        {
            // Sinh ra quái tại vị trí spawnPoint
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    int GetCurrentLevel()
    {
        int soSceneHienTai = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        return soSceneHienTai; 
    }
}
[System.Serializable]
public class ThongTinLevel
{
    public int Id;
    public int Level;
    public int Wave;
    public int LoaiQuai;
    public int SoLuong;
}