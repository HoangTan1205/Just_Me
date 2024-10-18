using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Scr_Start;
using static Scr_User_Login;
public class Start_Manager : MonoBehaviour
{
    [SerializeField] private List<In4User> listTTUser = new List<In4User>();
    [SerializeField] private Scr_Start data;
    [SerializeField] private Scr_User_Login u_login;
    [SerializeField] private string file;

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Login;

    public TextMeshProUGUI hienTTUserName;
    public TextMeshProUGUI LvUser;
    public TextMeshProUGUI hienTTDiemCao;

    public Toggle soundToggle;

    // Tham chiếu tới AudioSource để điều khiển âm thanh
    public AudioSource audioSource;

    // Biến int để lưu trạng thái 1 hoặc 0
    public int toggleValue;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        CheckTK();
    
    }
    private void Start()
    {
        file = "User";
        LoadTextLinh(file);

    }
    private void CheckTK()
    {
        SetActiveMenu();
        if (u_login.idUser != 0)
        {
            hienTTUserName.text = "Tên Đăng Nhập: " + u_login.userName;
            LvUser.text = "Màn Chơi Hiện Tại: " + u_login.levelUser.ToString();
            hienTTDiemCao.text = "Điểm Cao: " + u_login.diemCao.ToString();
            toggleValue = u_login.sound;
        }
        UpdateToggleAndSound();
        soundToggle.onValueChanged.AddListener(OnToggleChanged);


    }
    private void SetActiveMenu()
    {
        if (u_login.idUser != 0)
        {
            Menu.SetActive(true);
            Login.SetActive(false);
        }
        else
        {
            Menu.SetActive(false);
            Login.SetActive(true);
            
        }
    }


    void OnToggleChanged(bool isOn)
    {
        // Nếu Toggle bật, giá trị của biến là 1. Nếu tắt, giá trị là 0.
        toggleValue = isOn ? 1 : 0;
        u_login.sound = toggleValue;
        // Cập nhật trạng thái âm thanh dựa trên toggleValue
        UpdateSound();

    }

    // Hàm để cập nhật trạng thái âm thanh
    void UpdateSound()
    {
        // Bật hoặc tắt âm thanh dựa trên giá trị của toggleValue
        audioSource.mute = toggleValue == 0;
    }

    // Hàm để cập nhật cả trạng thái của Toggle và âm thanh
    void UpdateToggleAndSound()
    {
        // Thiết lập trạng thái của Toggle dựa trên giá trị của toggleValue
        soundToggle.isOn = toggleValue == 1;
        
        // Cập nhật trạng thái âm thanh
        UpdateSound();
    }

    public void LoadTextLinh(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            In4User tt = new In4User();
            tt.Id = Convert.ToInt32(cols[0]);
            tt.UserName = cols[1];
            tt.Pass = cols[2];
            tt.Level = Convert.ToInt32(cols[3]);
            tt.DiemCao = Convert.ToInt32(cols[4]);
            tt.AmThanh = Convert.ToInt32(cols[5]);
            listTTUser.Add(tt);

            if (data.List_User.Count < listTTUser.Count)
            {
                InforUser list = new InforUser(tt.Id, tt.UserName, tt.Pass, tt.Level, tt.DiemCao, tt.AmThanh);
                data.List_User.Add(list);
            }

        }
    }
}
[System.Serializable]
public class In4User
{
    public int Id;
    public string UserName;
    public string Pass;
    public int Level;
    public int DiemCao;
    public int AmThanh;
}
