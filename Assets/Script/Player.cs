using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 15f; // Control the jump force of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Check if the player is on the ground

    [SerializeField]
    private Transform groundCheck; // Reference to the ground check object

    [SerializeField]
    private float groundCheckRadius = 0.2f; // Radius of the ground check sphere

    [SerializeField]
    private LayerMask groundLayer; // Layer mask to specify which layers are considered ground

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded(); // Check if the player is grounded
        HandleJump(); // Handle player jump input
    }

    private bool CheckIfGrounded()
    {
        // Check if the player is touching the ground
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere at the ground check position to visualize the ground check area
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    public void HandleJump()
    {
        // Check if the player is grounded before allowing a jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce; // Apply an upward force to the player
        }
    }
}
