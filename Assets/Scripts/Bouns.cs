using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouns : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(9.8f * 25f, 9.8f * 25, transform.position.z));
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude; // magnitude = 거리(크기)
        var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = dir * Mathf.Max(speed, 0f);
    }
}
