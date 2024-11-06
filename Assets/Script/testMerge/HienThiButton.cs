using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HienThiButton : MonoBehaviour
{
    public List<GameObject> GridCreateLinh;
    public TextMeshProUGUI DiemVang;
    public GameObject LinhXuatTran;
    public GameObject LinhInstan;
    public GameObject ButtonXuatTran;
    public int giaLinh ;
    private int currentIndex = 0;
    private Dictionary<Vector3, GameObject> spawnedObjects = new Dictionary<Vector3, GameObject>();
    
    void Start()
    {
        
    }

    // public void TaoLinh()
    // {
    //     foreach (GameObject position in GridCreateLinh)
    //     {
    //         Instantiate(LinhXuatTran, position.transform.position, Quaternion.identity);
    //         ButtonXuatTran.SetActive(false);
    //     }
    // 
    // }
    public void XoaLinh()
    {
        int gold = Convert.ToInt32(DiemVang.text);
        DiemVang.text = (gold + giaLinh).ToString();
    }
    public void GiaLinh(int gia)
    {
        giaLinh = gia;
    }
    public void XuatTran(GameObject gameObject)
    {
        LinhXuatTran = gameObject;
    }
    public void Linh_Istan(GameObject gameObject)
    {
        LinhInstan = gameObject;
    }

    public void Click(int click)
    {
        if (click % 2 == 1)
        {
            ButtonXuatTran.SetActive(true);
        }
        if (click % 2 == 0)
        {
            ButtonXuatTran.SetActive(false);
        }
    }

    public void TaoLinh()
    {
        if (GridCreateLinh.Count == 0)
        {
            return;
        }

        int startingIndex = currentIndex;  // Lưu lại chỉ số ban đầu để tránh vòng lặp vô hạn

        do
        {
            Vector3 spawnPosition = GridCreateLinh[currentIndex].transform.position;
            GameObject checkO = GridCreateLinh[currentIndex].GetComponent<GridTaoLinh>().Tuong;
            bool check = GridCreateLinh[currentIndex].GetComponent<GridTaoLinh>().CheckTuong;

            if (!spawnedObjects.ContainsKey(spawnPosition) && check == false)
            {
                // Nếu vị trí hợp lệ và không có đối tượng nào được spawn, tiến hành spawn
                GameObject newObject = Instantiate(LinhInstan, spawnPosition, Quaternion.identity);
                spawnedObjects[spawnPosition] = newObject;
                break;  // Dừng vòng lặp sau khi spawn
            }
            else
            {
                // Chuyển sang vị trí tiếp theo nếu vị trí hiện tại đã có đối tượng
                currentIndex = (currentIndex + 1) % GridCreateLinh.Count;
            }
        }
        while (currentIndex != startingIndex);  // Thoát vòng lặp khi đã kiểm tra tất cả vị trí
        Destroy(LinhXuatTran);
        ButtonXuatTran.SetActive(false);
    }

    

}
