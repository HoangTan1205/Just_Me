using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTaoLinh : MonoBehaviour
{
    public bool CheckTuong;
    public GameObject Tuong;
    public void TakeViTri(bool check)
    {
        if(Tuong == null)
        {
            CheckTuong = check;
        }      
            
    }
    public void TuongTrongO(GameObject gameObject)
    {
        Tuong = gameObject;
        
    }
}
