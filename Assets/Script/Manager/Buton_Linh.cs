using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
using static Scr_Load_Price_Linh;
public class Buton_Linh : MonoBehaviour
{
    public int level;
    public Button[] Linh_Buttons;
    public Image[] price;
    public TextMeshProUGUI[] textPriceButton;
    public GameObject Linh_Kiem;
    public GameObject Xa_Thu;
    public GameObject Knight;
    public GameObject Ninja;
    public Transform tower;
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textNangLuong;
    public int nangLuong = 0; // Số nl hiện tại
    public int nangLuongMoiGiay = 10;
    private float thoiGianTangNL = 0f;

    public Scr_Load_Price_Linh price_Linh;
    public List<Price_Linh> list_price = new List<Price_Linh>();
    private void Awake()
    {        
        LoadPrice("Price_Linh");
        level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        textLevel.text = "Level " + level.ToString();
        UnlockLinh();
    }
    private void Start()
    {
        
    }
    void Update()
    {
        TangVangMoiGiay();
    }
    void TangVangMoiGiay()
    {
        thoiGianTangNL += Time.deltaTime;
        if (thoiGianTangNL >= 1f)
        {
            nangLuong += nangLuongMoiGiay;
            thoiGianTangNL = 0f;
            textNangLuong.text =  nangLuong.ToString(); // Cập nhật hiển thị vàng sau mỗi lần tăng
        }
    }
    public void LoadPrice(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            Price_Linh tt = new Price_Linh();
            tt.Id = Convert.ToInt32(cols[0]);
            tt.Price = Convert.ToInt32(cols[1]);
            list_price.Add(tt);

            if(price_Linh.List_Price.Count < list_price.Count)
            {
                Data_Price_Linh list_scr = new Data_Price_Linh(tt.Id, tt.Price);
                price_Linh.List_Price.Add(list_scr);
            }
        }
    }
    void UnlockLinh()
    {
        for (int i = 0; i < Linh_Buttons.Length; i++)
        {

            if (i + 1 <= level)
            {
                textPriceButton[i].text = Gia_NangLuong(i + 1).ToString();
                price[i].gameObject.SetActive(true);
                Linh_Buttons[i].gameObject.SetActive(true);

                
            }
            else
            {
                price[i].gameObject.SetActive(false);
                Linh_Buttons[i].gameObject.SetActive(false);
            }
        }
    }
    public void TamDung()
    {
        Time.timeScale = 0f;
    }
    public void TiepTuc()
    {
        Time.timeScale = 1;
    }

    public void ChoiLai()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
        Time.timeScale = 1f; // Đảm bảo game tiếp tục chạy sau khi tải lại
    }
    public void VeHome()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }


    public void Instan_Linh_Kiem()
    {
        if(Gia_NangLuong(1) <= nangLuong)
        {
            nangLuong = nangLuong - Gia_NangLuong(1);
            GameObject Linh = Instantiate(Linh_Kiem, tower.position, Quaternion.identity);
        }
    }
    public void Instan_Xa_Thu()
    {
        if (Gia_NangLuong(2) <= nangLuong)
        {
            nangLuong = nangLuong - Gia_NangLuong(2);
            GameObject Linh = Instantiate(Xa_Thu, tower.position, Quaternion.identity);
        }
    }
    public void Instan_Knight()
    {
        if (Gia_NangLuong(3) <= nangLuong)
        {
            nangLuong = nangLuong - Gia_NangLuong(3);
            GameObject Linh = Instantiate(Knight, tower.position, Quaternion.identity);
        }
    }
    public void Instan_Ninja()
    {
        if (Gia_NangLuong(4) <= nangLuong)
        {
            nangLuong = nangLuong - Gia_NangLuong(4);
            GameObject Linh = Instantiate(Ninja, tower.position, Quaternion.identity);
        }
    }
    public int Gia_NangLuong(int id)
    {
        var tim = price_Linh.List_Price.FirstOrDefault(s => s.Id == id);
        return tim.Price;
    }

}
[System.Serializable]
public class Price_Linh
{
    public int Id;
    public int Price;
}
