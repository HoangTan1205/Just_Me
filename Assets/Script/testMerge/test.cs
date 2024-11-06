using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    
    public int click = 0 ;

    public int gia = 2;
    private void Start()
    {

        // canva = GameObject.FindWithTag("ButtonTaoLinh");
    }
    // void OnMouseDown()
    // {
    //     click++;
    //     if (click%2==1)
    //     {
    //         canva.GetComponent<HienThiButton>().Click(click);
    //         canva.GetComponent<HienThiButton>().GiaLinh(gia);
    //         canva.GetComponent<HienThiButton>().XuatTran(gameObject);
    //         //canva.SetActive(true);
    //     }
    //     else
    //     {
    // 
    //         //canva.SetActive(false);
    //     }
    // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Luoi"))
        {           
            Debug.Log("Da_Cham");
            if(collision.gameObject.GetComponent<GridTaoLinh>().CheckTuong == false)
            {                       
                // collision.gameObject.GetComponent<GridTaoLinh>().TakeViTri(true);            
                //collision.gameObject.GetComponent<GridTaoLinh>().TuongTrongO(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Luoi"))
        {
            Debug.Log("Thoat_Cham");
            if(collision.gameObject.GetComponent<GridTaoLinh>().Tuong == gameObject)
            {
                collision.gameObject.GetComponent<GridTaoLinh>().TuongTrongO(null);
                collision.gameObject.GetComponent<GridTaoLinh>().TakeViTri(false);
            }
        }
    }

    
        
}
