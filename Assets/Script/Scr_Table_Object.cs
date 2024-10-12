using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "DataLinh", menuName = ("ChiSo/Linh"), order = 1)]
public class Scr_Table_Object : ScriptableObject
{
    public List<TableObject> tableObjects = new List<TableObject>();
    [System.Serializable]
    public class TableObject
    {
        public int Id;
        public string Linh;
        public float Hp;
        public float Dmg;
        public float TocDoChay;
        public float TocDoBan;
        public float TamBan;

        public TableObject(int id, string linh, float hp, float dmg, float tocDoChay, float tocDoBan, float tamBan)
        {
            Id = id;
            Linh = linh;
            Hp = hp;
            Dmg = dmg;
            TocDoChay = tocDoChay;
            TocDoBan = tocDoBan;
            TamBan = tamBan;        
        }
    }    
}
