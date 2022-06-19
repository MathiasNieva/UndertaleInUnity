using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 0;
    public bool jump;
    private float move;
    private Vector2 startingPosition = new Vector2(0, -1.8f);
    Rigidbody2D rb;
    public PlayerHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetHeart();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2( move * speed, rb.velocity.y);
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (jump && Input.GetButton("Jump") && jumpForce < 6.5)
        {
            jumpForce = jumpForce + 0.05f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            jumpForce = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp.TakeDamage(1);
        }
    }

    public void SetHeart()
    {
        transform.position = startingPosition;
    }
}
