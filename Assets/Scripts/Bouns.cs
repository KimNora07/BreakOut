using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouns : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
        
    private void Update()
    {
        if(transform.position.y < minY){
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
        }

        if(rb.velocity.magnitude > maxVelocity){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
}
