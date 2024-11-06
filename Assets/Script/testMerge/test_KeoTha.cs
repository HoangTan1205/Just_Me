using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class test_KeoTha : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public SceneSpwanManager spwanManager;

    public List<GameObject> ObjectPositions;

    public GameObject canva;
    public int click = 0;
    public Transform viTriO;
    public GameObject IstanLinh;
    public bool Merge;
    public Transform MergeTranform;
    public GameObject ObjectMerge;
    private void Start()
    {
        spwanManager = FindFirstObjectByType<SceneSpwanManager>();
        ObjectPositions = spwanManager.ObjectPositions;
        canva = GameObject.FindWithTag("ButtonTaoLinh");
    }
    void OnMouseDown()
    {
        // offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        click++;       
        canva.GetComponent<HienThiButton>().Click(click);          
        canva.GetComponent<HienThiButton>().XuatTran(gameObject);
        canva.GetComponent<HienThiButton>().Linh_Istan(IstanLinh);



    }

    void OnMouseDrag()
    {
        // if (isDragging)
        // {
        //     transform.position = GetMouseWorldPosition() + offset;       
        // }

        if (isDragging)
        {
            // Lấy vị trí của chuột trên màn hình
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;

            // Chuyển đổi vị trí chuột từ màn hình sang thế giới
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Cập nhật vị trí của đối tượng
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        SetViTri();
        //SnapToGrid();
    }

    

    void SnapToGrid()
    {
        // Vector3 closestPosition = transform.position;
        // float shortestDistance = Mathf.Infinity;
        // GameObject closestObject = null;
        // foreach (GameObject o in ObjectPositions)
        // {
        //     // Lấy component GridTaoLinh và kiểm tra null
        //     var gridComponent = o.GetComponent<GridTaoLinh>();
        //     if (gridComponent == null)
        //     {
        //         continue;  // Nếu không có GridTaoLinh, bỏ qua đối tượng này
        //     }
        // 
        //     // Lấy khoảng cách và các thuộc tính kiểm tra
        //     float distance = Vector3.Distance(transform.position, o.transform.position);
        //     bool check = gridComponent.CheckTuong;
        //     GameObject TuongtrongO = gridComponent.Tuong;
        // 
        //     // Kiểm tra nếu khoảng cách gần nhất và không có đối tượng tại vị trí này
        //     if (distance < shortestDistance && TuongtrongO == null )
        //     {
        //         shortestDistance = distance;
        //         closestPosition = o.transform.position;
        //         closestObject = o;
        //     }
        // }
        // 
        // transform.position = closestPosition;
        // if (closestObject != null)
        // {
        //     closestObject.GetComponent<GridTaoLinh>().TuongTrongO(gameObject);
        // }

    }   
    
    void SetViTri()
    {
        // Vector3 vitri = new Vector3(viTriO.position.x, viTriO.position.y - 0.7f, viTriO.position.z);
        transform.position = viTriO.position;
        if (Merge)
        {
            Instantiate(ObjectMerge, MergeTranform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(MergeTranform.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Luoi"))
        {
            var gridComponent = collision.GetComponent<GridTaoLinh>();
            if (gridComponent.CheckTuong == false && gridComponent.Tuong == null)
            {
                viTriO = collision.transform;
                collision.gameObject.GetComponent<GridTaoLinh>().TakeViTri(true);
                collision.GetComponent<GridTaoLinh>().TuongTrongO(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Linh"))
        {
            Debug.Log("LinhChamLinh");
            MergeTranform = collision.transform;
            var loaiQuai = collision.GetComponent<testMerge>();
            var loai = GetComponent<testMerge>().enemyType;
            if (loaiQuai.enemyType == loai)
            {
                Debug.Log("Merge");
                Merge = true;

            }
        }       
    }    
}
