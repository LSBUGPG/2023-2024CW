using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inputX; // Contain the value for the players input.
    private float speed = 5f; // Multiplier for the players movement speed.

    private float jumpForce = 10f; // How high the player will jump
    private bool isJumping = false;

    private Rigidbody2D rb; // Contains a reference to the players rigidbody.

    [SerializeField] private LayerMask groundLayer; // The ground layer for ground check
    [SerializeField] private Transform groundCheck; // The origin of the overlap circle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // References the players rigidbody.
    }

    void Update() // Updates every frame.
    {
        inputX = Input.GetAxisRaw("Horizontal"); // Every frame get the players horizontal movement.

        if (Input.GetButtonDown("Jump")) isJumping = true; // When jump key pressed set jump value to true.
    }

    private void FixedUpdate() // For physics updates.
    {
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y); // Update the players movement.

        if (isJumping && IsGrounded()) // If the jump key is pressed.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Add jump velocity
            isJumping = false; // Update is jumping to false so the player doesn't infinitely go up.
        }
        else // If player is not grounded
        {
            isJumping = false; // Set this to false to prevent queing jump
        }
    }

    private bool IsGrounded() // Function for ground check
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer); // returns true or false depending on if the cirle is overlaping the ground or not.
    }
}
