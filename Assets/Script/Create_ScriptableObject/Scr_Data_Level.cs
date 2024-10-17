using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataLevel", menuName = ("ThongTin/Level"))]
public class Scr_Data_Level :ScriptableObject
{
    public List<InforLevel> List_Data_Level = new List<InforLevel>();
    [System.Serializable]
    public class InforLevel
    {
        public int Id;
        public int Level;
        public int Wave;
        public int LoaiQuai;
        public int SoLuong;

        public InforLevel(int id, int level, int wave, int loaiQuai, int soLuong)
        {
            Id = id;
            Level = level;
            Wave = wave;
            LoaiQuai = loaiQuai;
            SoLuong = soLuong;
        }
        

    }
    
}
