using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gold_Manager : MonoBehaviour
{
    public static Gold_Manager instance; // Đối tượng singleton
    public TextMeshProUGUI gold;
    public int goldAmount = 0; // Số lượng vàng hiện tại

    public GameObject objectPrefab; // Prefab của đối tượng cần sinh ra
    public List<Vector3> spawnPositions; // Danh sách các vị trí spawn
    public List<GameObject> ObjectPositions;
    public Button spawnButton; // Nút để kích hoạt spawn

    private int currentIndex = 0;
    private Dictionary<Vector3, GameObject> spawnedObjects = new Dictionary<Vector3, GameObject>();

    void Start()
    {
        foreach (GameObject obj in ObjectPositions)
        {
            Vector3 po = obj.transform.position;
            spawnPositions.Add(po);
        }
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnAtPositions);
        }
    }

    void SpawnAtPositions()
    {
        
        foreach (Vector3 position in spawnPositions)
        {

            Instantiate(objectPrefab, position, Quaternion.identity);
        }
       
    }
    public void SpawnObject()
    {
        if (spawnPositions.Count == 0)
        {
            Debug.LogWarning("No spawn positions set.");
            return;
        }

        // Lấy vị trí từ danh sách
        Vector3 spawnPosition = spawnPositions[currentIndex];

        // Kiểm tra nếu đã có đối tượng ở vị trí này
        if (!spawnedObjects.ContainsKey(spawnPosition))
        {
            // Tạo đối tượng và thêm vào từ điển
            GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedObjects[spawnPosition] = newObject;
        }
        else
        {
            Debug.LogWarning("Position already occupied, moving to next position.");
        }

        // Cập nhật index để vòng lặp qua các vị trí
        currentIndex = (currentIndex + 1) % spawnPositions.Count;
    }

    private void Update()
    {
        gold.text = goldAmount.ToString();
    }
    private void Awake()
    {
        // Kiểm tra xem có đối tượng GoldManager nào khác không
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại đối tượng này giữa các scene
        }
        else
        {
            Destroy(gameObject); // Xóa đối tượng trùng lặp
        }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        
    }
}
