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
    public AudioSource audioSource;
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

        string test = PlayerPrefs.GetString("saveGame");

    }
    public void CheckTK()
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

        string abc = "asdfasdfsf";

        //Luu
        PlayerPrefs.SetString("saveGame", abc);



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

        toggleValue = isOn ? 1 : 0;
        u_login.sound = toggleValue;
        UpdateSound();

    }

    void UpdateSound()
    {
        audioSource.mute = toggleValue == 0;
    }

    void UpdateToggleAndSound()
    {
        soundToggle.isOn = toggleValue == 1;      
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
