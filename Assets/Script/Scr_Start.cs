using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataUser", menuName = ("ThongTin"), order = 1)]
public class Scr_Start : ScriptableObject
{
    public List<InforUser> List_User = new List<InforUser>();
    [System.Serializable]
    public class InforUser
    {
        public int Id;
        public string UserName;
        public string Pass;
        public int Level;
        public int DiemCao;
        public int AmThanh;

        public InforUser(int id, string userName, string pass, int level, int diemCao, int amThanh)
        {
            Id = id;
            UserName = userName;
            Pass = pass;
            Level = level;
            DiemCao = diemCao;
            AmThanh = amThanh;
        }


    }
}
