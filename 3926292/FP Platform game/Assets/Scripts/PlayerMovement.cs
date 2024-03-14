using System.Collections;
using UnityEngine;
//This code was written following a YouTube tutorial: youtube.com/watch?v=f473C43s8nE
public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    [Header("Keybinds")]

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode slideKey = KeyCode.C;

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float slideSpeed;
    public float sprintSpeed;
    private bool isSprinting;

    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;

    public float speedIncreaseMultiplier;
    public float slopeIncreaseMultiplier; 

    [Header("Slopes")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;


    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    private bool isSliding; 

    //Crouching 
    public float crouchSpeed;
    public float crouchSize;
    private float regScale;


    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    public Transform orientation;
    public Transform playerObj;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public MovementState state;
    public enum MovementState
    {
        Walking,
        Sprinting,
        Crouching, 
        Sliding,
        Air,
    }



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        regScale = transform.localScale.y;

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchSize, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, regScale, transform.localScale.z);
        }
        if (Input.GetKeyDown(slideKey) && isSprinting && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }

        if (Input.GetKeyUp(slideKey) && isSliding)
        {
            StopSlide();
        }
    }
   private void StateHandler()
        {
            if (Input.GetKey(crouchKey))
            {
                state = MovementState.Crouching;
                desiredMoveSpeed = crouchSpeed;
            }

            if (grounded && Input.GetKey(sprintKey))
            {
                state = MovementState.Sprinting;
                desiredMoveSpeed = sprintSpeed;
                isSprinting = true;
            }
            else if (grounded)
            {
                state = MovementState.Walking;
                desiredMoveSpeed = walkSpeed;
            }
            else
            {
                state = MovementState.Air;
            } 
            if(Input.GetKeyUp(sprintKey))
            {
                isSprinting = false;
            } 
            if (isSliding)
            {
               state = MovementState.Sliding;

               if (OnSlope() && rb.velocity.y < 0.1f)
                desiredMoveSpeed = slideSpeed;
               else
                desiredMoveSpeed = sprintSpeed;
            }
        if(Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 4f && moveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
        {
            moveSpeed = desiredMoveSpeed;
        }
        lastDesiredMoveSpeed = desiredMoveSpeed;
   } 

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed; 

        while (time < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);
           
            if(OnSlope())
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
            } 
            else
            {
                time += Time.deltaTime * speedIncreaseMultiplier;
            }
            yield return null;
        }
        moveSpeed = desiredMoveSpeed;
    }
        private void MovePlayer()
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            //grounded
            if (grounded)
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            //Air
            else if (!grounded)
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            //Slope 
            if(OnSlope() && !exitingSlope)
            {
                rb.AddForce(GetSlopeMoveDirection(moveDirection) * moveSpeed * 20f, ForceMode.Force);

              if (rb.velocity.y < 0f)
              {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
              }
            }
             
             //gravity on slope = off 
             rb.useGravity = !OnSlope();

        }
        private void Update()
        {
            MyInput();
            StateHandler();
            SpeedControl();
            //groundcheck 
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);

            // handle drag 
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;

        }

        private void FixedUpdate()
        {
            MovePlayer();
            
          if (isSliding)
            SlidingMovement();
        }

        private void SpeedControl()
        {
            if (OnSlope() && !exitingSlope)
            {
               if (rb.velocity.magnitude > moveSpeed)
                   rb.velocity = rb.velocity.normalized * moveSpeed;
            } 
            //limiting speed on ground and air
            else
            {
              Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                //limit velocity if needed
                if (flatVel.magnitude > moveSpeed)
                {
                  Vector3 LimitedVel = flatVel.normalized * moveSpeed;
                  rb.velocity = new Vector3(LimitedVel.x, rb.velocity.y, LimitedVel.z);
                }
            }
        }
        private void Jump()
        {
            exitingSlope = true;
            //resets the y velocity to zero why maintaining rigidbody velocity for xz axis
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        private void ResetJump()
        {
            readyToJump = true;
            exitingSlope = false;
        } 
        private bool OnSlope()
        {
           if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.1f))
           {
               float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
               return angle < maxSlopeAngle && angle != 0;
           }
           
           return false;
        } 

    private Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    private void StartSlide()
    {
        isSliding = true;

        playerObj.localScale = new Vector3(playerObj.localScale.x, crouchSize, playerObj.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        slideTimer = maxSlideTime;
    }

    private void SlidingMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (!OnSlope() || rb.velocity.y > -0.1f)
        {
            rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

            slideTimer -= Time.deltaTime;
        }
        else
        {
            rb.AddForce(GetSlopeMoveDirection(inputDirection) * slideForce, ForceMode.Force);
        } 
        
        if (slideTimer <= 0)
            StopSlide();
    }

    private void StopSlide()
    {
        isSliding = false;
        playerObj.localScale = new Vector3(playerObj.localScale.x, regScale, playerObj.localScale.z);
    }
}


