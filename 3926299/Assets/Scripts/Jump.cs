using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpForce = 10;
    public float groundDistance = 1f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            rigidBody.velocity = Vector3.up * jumpForce;
        }
    }

}
