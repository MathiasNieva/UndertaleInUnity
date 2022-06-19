using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 7f;
    Animator animator;
    Vector2 move;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //rb.velocity = move * speed; 
        rb.MovePosition(rb.position + (move * speed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log(move);
        animator.SetFloat("SpeedX", move.x * speed);
        animator.SetFloat("SpeedY", move.y * speed);
    }
}
