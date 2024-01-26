using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouns : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    public float moveSpeed = 25f;

    public GameObject gameoverPanel;
    private void Awake()
    {
        gameoverPanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(9.8f * moveSpeed, 9.8f * moveSpeed));
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = dir * Mathf.Max(speed, 0f);
        if (moveSpeed < 75f)
        {
            moveSpeed += 5f;
            rb.AddForce(dir * moveSpeed / 100f, ForceMode2D.Impulse);
        }
        if(collision.gameObject.name == "Down")
        {
            gameoverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
