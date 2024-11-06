using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Burst.Intrinsics.X86;


public class SceneSpwanManager : MonoBehaviour
{
    public static Gold_Manager instance; // Đối tượng singleton
    public int vangcanCo = 50;

    public int vangHienTai;
    public GameObject objectPrefab; // Prefab của đối tượng cần sinh ra
    public List<GameObject> ObjectPositions;
    public Button spawnButton; // Nút để kích hoạt spawn

    private int currentIndex = 0;
    private Dictionary<Vector3, GameObject> spawnedObjects = new Dictionary<Vector3, GameObject>();

    void Start()
    {
        
        if (spawnButton != null)
        {
            spawnButton.onClick.AddListener(SpawnObject);
        }
    }
    private void Update()
    {
        
    }
    void SpawnAtPositions()
    {
        foreach (GameObject position in ObjectPositions)
        {
            Instantiate(objectPrefab, position.transform.position, Quaternion.identity);
        }

    }
    public void SpawnObject()
    {
        if (ObjectPositions.Count == 0)
        {
            return;
        }

        int startingIndex = currentIndex;  // Lưu lại chỉ số ban đầu để tránh vòng lặp vô hạn

        do
        {
            Vector3 spawnPosition = ObjectPositions[currentIndex].transform.position;  
            
            var ViTri = ObjectPositions[currentIndex].GetComponent<GridTaoLinh>();
            GameObject checkO = ViTri.Tuong;
            bool check = ViTri.CheckTuong;

            var spE = FindFirstObjectByType<SpawnE>();
            vangHienTai = spE.gold;

            if (check == false && checkO == null && vangHienTai>= vangcanCo)
            {
                spE.TaoLinh(vangcanCo);
                // Nếu vị trí hợp lệ và không có đối tượng nào được spawn, tiến hành spawn
                GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
                spawnedObjects[spawnPosition] = newObject;

                break;  // Dừng vòng lặp sau khi spawn
            }
            else
            {
                // Chuyển sang vị trí tiếp theo nếu vị trí hiện tại đã có đối tượng
                currentIndex = (currentIndex + 1) % ObjectPositions.Count;
            }
        }
        while (currentIndex != startingIndex);  // Thoát vòng lặp khi đã kiểm tra tất cả vị trí
    }

    


    
}
