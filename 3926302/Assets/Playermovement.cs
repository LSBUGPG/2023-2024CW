using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private float horizontal;
    [Header("Values to adjust")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpingPower = 10f;
    private bool justJumped = false;
    [Header("Objects")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump")) justJumped = true;
        if (Input.GetButtonUp("Jump")) justJumped = false;

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(justJumped && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            justJumped = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundlayer);
    }

    private void Flip()
    {
        switch(horizontal)
        {
            case 1:
                sprite.flipX = false;
                break;
            case -1:
                sprite.flipX = true;
                break;
        }
    }
} 