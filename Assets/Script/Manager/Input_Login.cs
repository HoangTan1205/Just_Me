using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class Input_Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TextMeshProUGUI messageText;
    public Scr_Start dataUser;

    public int idUser;
    public string userName;
    public string passwordUser;
    public int levelUser;
    public int diemCao;
    public int sound;
    public TextMeshProUGUI hienTTUserName;
    public TextMeshProUGUI LvUser;
    public TextMeshProUGUI hienTTDiemCao;

    public GameObject Menu;
    public GameObject Login;

    void Start()
    {
        
    }

    public void OnLoginButton()
    {
        string username = usernameField.text;
        string password = passwordField.text;
        if (CheckInput(username, password))
        {
            messageText.text = "Đăng nhập thành công! Đang tải dữ liệu...";
            
        }
        else
        {
            messageText.text = "Sai tên đăng nhập hoặc mật khẩu!";
        }
    }

    private bool CheckInput(string username, string password)
    {
        var user = dataUser.List_User.FirstOrDefault(u => u.UserName == username && u.Pass == password);
        if ( user!=null )
        {
            idUser = user.Id;
            userName = user.UserName;
            passwordUser = user.Pass;
            levelUser = user.Level;
            diemCao = user.DiemCao;
            hienTTUserName.text = "Tên Đăng Nhập: "+user.UserName;
            LvUser.text = "Màn Chơi Hiện Tại: "+user.Level.ToString();
            hienTTDiemCao.text = "Điểm Cao: "+user.DiemCao.ToString();
            Invoke("SetActiveMenu", 1.5f);
            Invoke("ClearInput", 2f);


            return true;  
        }
         return false;  
    }

    private void SetActiveMenu()
    {
        Login.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);       
    }

    private void ClearInput()
    {
        usernameField.text = "";
        passwordField.text = "";
        messageText.text = "";

    }

}