using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_Ninja : Linh_Manager
{
    private Rigidbody2D rig;
    public float move = 250f;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move(Vector2.right, move, rig);
    }
}
