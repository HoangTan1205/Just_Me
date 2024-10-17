using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Price_Linh", menuName = ("ThongTin/Price_Linh"))]
public class Scr_Load_Price_Linh : ScriptableObject
{
    public List<Data_Price_Linh> List_Price = new List<Data_Price_Linh>();
    [System.Serializable]
    public class Data_Price_Linh
    {
        public int Id;
        public int Price;

        public Data_Price_Linh(int id, int price)
        {
            Id = id;
            Price = price;
        }
    }
}
