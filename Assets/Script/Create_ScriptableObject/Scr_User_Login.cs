using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataUserLogin", menuName = ("ThongTin/Data"))]
public class Scr_User_Login : ScriptableObject
{
    public int idUser;
    public string userName;
    public string passwordUser;
    public int levelUser;
    public int diemCao;
    public int sound;
}
