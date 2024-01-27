using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float maxX = 7.5f;
    float moveHorizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveHorizontal =  Input.GetAxisRaw("Horizontal");
        if((moveHorizontal > 0 && transform.position.x < maxX) || 
          (moveHorizontal < 0 && transform.position.x > -maxX))
        {
            transform.position += Vector3.right * moveHorizontal * moveSpeed * Time.deltaTime;
        }
    }
}
