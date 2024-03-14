using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public float jumpForce;
    public float airMultiplier;
    public int stamina;
    private bool sprinting;
    private bool recharging;
    bool readyToJump = true;
    bool doubleJumped = false;
    bool InAir = false;

    bool readyToDashOne = true;
    bool readyToDashTwo = true;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    public Transform Orientation;

    float HorizontalInput;
    float VerticalInput;

    Vector3 MoveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
        {
            rb.drag = groundDrag;
            doubleJumped = false;
            if (InAir)
            {
                InAir = false;
                readyToJump = true;
            }
        }
        else
        {
            rb.drag = 0;
        }
        MyInput();
        SpeedControl();

    }

    void FixedUpdate()
    {
        if (Input.GetKey(sprintKey) && stamina > 0 && recharging == false)
        {
            Sprint();
        }
        if ((Input.GetKey(sprintKey) == false && stamina < 300) || recharging == true)
        {
            Recharge();
        }
        MovePlayer();
    }

    // Update is called once per frame
    void MyInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readyToJump == true)
        {
            readyToJump = false;
            Jump();
        }
        if (Input.GetKey(jumpKey) == false && readyToJump == false)
        {
            readyToJump = true;
        }
        if (Input.GetMouseButtonDown(1) && readyToDashOne == true && readyToDashTwo == true)
        {
            readyToDashOne = false;
            Dash();
        }
        if (Input.GetMouseButtonDown(1) && readyToDashOne == false)
        {
            readyToDashOne = true;
        }
    }

    void MovePlayer()
    {
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;
        if (grounded)
        {
            rb.AddForce(MoveDirection * Speed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(MoveDirection * Speed * 10f * airMultiplier, ForceMode.Force);

        }
    }

    void SpeedControl()
    {
        Vector3 HorizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (HorizontalVelocity.magnitude > Speed)
        {
            Vector3 limitedVel = HorizontalVelocity.normalized * Speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        if (doubleJumped == false) 
        {
            if (!grounded)
            {
                doubleJumped = true;
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            }
            else
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                Invoke("SetInAir", 0.2f);
            }
        }
    }

    void Dash()
    {
        readyToDashTwo = false;
        rb.AddForce(Orientation.forward * 160.0f, ForceMode.Impulse);
        Invoke("ResetDash", 1.0f);
    }
    void ResetDash()
    {
        readyToDashTwo = true;
    }

    void SetInAir()
    {
        InAir = true;
    }

    void Sprint()
    {
        recharging = false;
        sprinting = true;
        stamina = stamina - 1;
        Speed = 7;
        if (stamina <= 0)
        {
            stamina = 0;
            sprinting = false;
            recharging = true;
        }
    }

    void Recharge()
    {

        sprinting = false;
        recharging = true;

        stamina = stamina + 2;
        Speed = 5;
        if (stamina >= 300)
        {
            stamina = 300;
            sprinting = false;
            recharging = false;
        }
    }
}
