using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public Transform camera;

    public float speed = 5f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public Animator animator;
    private float velocity = 0.0f;

    Vector3 Gvelocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 3f;

    private bool isJumping;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && Gvelocity.y < 0)
        {
            Gvelocity.y = -2f;

            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;

        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (direction != Vector3.zero)
        {
            velocity = speed;
        }
        else
        {
            velocity = 0.0f;
        }

        animator.SetFloat("Speed", velocity);
        playerController.SimpleMove(direction.normalized * velocity);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Gvelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            animator.SetBool("isJumping", true);
            isJumping = true;
        }

        Gvelocity.y += gravity * Time.deltaTime;

        playerController.Move(Gvelocity * Time.deltaTime);
    }
}
