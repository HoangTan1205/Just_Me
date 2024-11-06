using UnityEngine;
using UnityEngine.EventSystems;

public class KeoThaSP : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform startParent;
    private SpwamEnemy spwamEnemy; // Tham chiếu đến GridManager
    private Enemy enemyComponent;    // Thành phần Enemy của kẻ địch này


   
    void Start()
    {
        spwamEnemy = GetComponent<SpwamEnemy>();
        enemyComponent = GetComponent<Enemy>(); // Lấy thành phần Enemy
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        bool merged = false;

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Mergeable"))
            {
                Enemy otherEnemyComponent = collider.GetComponent<Enemy>();

                // Kiểm tra nếu loại của hai kẻ địch giống nhau
                if (otherEnemyComponent != null && enemyComponent.enemyType == otherEnemyComponent.enemyType)
                {
                    MergeWithEnemy(collider.gameObject);
                    merged = true;
                    break;
                }
            }
        }

        if (!merged)
        {
            transform.position = startPosition;
        }
    }

    void MergeWithEnemy(GameObject otherEnemy)
    {
        Destroy(gameObject);
        Destroy(otherEnemy);

        Vector3 spawnPosition = otherEnemy.transform.position;
        Instantiate(spwamEnemy.enemyPrefab3, spawnPosition, Quaternion.identity);
    }

    //-----------------------------------------------------------------------------------------------

    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    void OnMouseDown()
    {
        // Bắt đầu kéo đối tượng
        isDragging = true;
        originalPosition = transform.position; // Lưu vị trí ban đầu
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        // // Kết thúc kéo đối tượng
        isDragging = false;
        // 
        // // Kiểm tra xem có đối tượng nào ở vị trí này không
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        // bool merged = false; // Biến để theo dõi việc hợp nhất
        // 
        // foreach (Collider2D collider in colliders)
        // {
        //     Merge mergeable = collider.GetComponent<Merge>();
        //     if (mergeable != null && mergeable.gameObject != gameObject)
        //     {
        //         mergeable.CheckForMerge();
        //         merged = true; // Đánh dấu đã hợp nhất
        //         break; // Dừng lại sau khi hợp nhất
        //     }
        // }
        // 
        // // Nếu không hợp nhất, đưa đối tượng trở về vị trí ban đầu
        // if (!merged)
        // {
        //     transform.position = originalPosition;
        // }

        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        bool merged = false;

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Mergeable"))
            {
                Enemy otherEnemyComponent = collider.GetComponent<Enemy>();

                // Kiểm tra nếu loại của hai kẻ địch giống nhau
                if (otherEnemyComponent != null && enemyComponent.enemyType == otherEnemyComponent.enemyType)
                {
                    MergeWithEnemy(collider.gameObject);
                    merged = true;
                    break;
                }
            }
        }

        if (!merged)
        {
            transform.position = startPosition;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            // Cập nhật vị trí đối tượng theo chuột
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Lấy vị trí chuột trong không gian thế giới
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // Thiết lập khoảng cách để có vị trí 2D
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

