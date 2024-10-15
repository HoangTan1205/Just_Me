using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using static Scr_User_Login;
using static Scr_Start;
public class Input_Login : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TextMeshProUGUI messageText;
    public Scr_Start dataUser;
    public Scr_User_Login userLogin;

    
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
            userLogin.idUser = user.Id;
            userLogin.userName = user.UserName;
            userLogin.passwordUser = user.Pass;
            userLogin.levelUser = user.Level;
            userLogin.diemCao = user.DiemCao;
            userLogin.sound = user.AmThanh;

            hienTTUserName.text = "Tên Đăng Nhập: "+user.UserName;
            LvUser.text = "Màn Chơi Hiện Tại: "+user.Level.ToString();
            hienTTDiemCao.text = "Điểm Cao: "+user.DiemCao.ToString();
            Invoke("SetActiveMenu", 1.5f);
            Invoke("ClearInput", 2f);


            return true;  
        }
         return false;  
    }
    public int ThemID()
    {
        int tim = dataUser.List_User.Max(tt => tt.Id);
        return tim + 1;
    }

    public void DangKy()
    {
        if (string.IsNullOrEmpty(usernameField.text) )
        {
            messageText.text = "Tên Đăng Nhập không được để trống";
            return;  
        }
        else if (string.IsNullOrEmpty(passwordField.text))
        {
            messageText.text = "Mật khẩu không được để trống";
            return;
        }

        // Kiểm tra xem tài khoản đã tồn tại chưa
        if (KiemTraUserName(usernameField.text))
        {
            messageText.text = "Tên Đăng Nhập đã tồn tại";
        }
        else
        {
            InforUser list = new InforUser(ThemID(), usernameField.text, passwordField.text, 1, 0,1);
            dataUser.List_User.Add(list);
            messageText.text = "Đăng Ký thành công! Đang tải dữ liệu...";
        }
    }

    private bool KiemTraUserName(string usernameToCheck)
    {       
        // Kiểm tra xem username đã tồn tại chưa
        foreach (var account in dataUser.List_User)
        {
            string accountData = account.UserName;

            if (accountData == usernameToCheck)
            {
                return true;
            }
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