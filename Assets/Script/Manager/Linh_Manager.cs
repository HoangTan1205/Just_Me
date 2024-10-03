using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_Manager : MonoBehaviour
{
    
    // Hàm di chuyển
    public virtual void Move(Vector2 direction, float moveSpeed, Rigidbody2D rig)
    {
        Vector3 move = new Vector3(direction.x, direction.y,0) * moveSpeed * Time.deltaTime;
        rig.velocity = move;

    }
}
