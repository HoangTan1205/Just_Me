using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Game : MonoBehaviour
{
    public Scr_User_Login Scr_User_Login;
    
    public void TiepTuc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scr_User_Login.levelUser);
    }
}
