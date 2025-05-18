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
    private Animator animator; // Reference to the Animator component
    [SerializeField]
    private BoxCollider2D normalCollider; // Reference to the BoxCollider2D component
    [SerializeField]
    private CapsuleCollider2D duckCollider; // Reference to the CapsuleCollider2D component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        animator = GetComponent<Animator>(); // Get the Animator component attached to the player
        normalCollider.enabled = true; // Enable the normal collider
        duckCollider.enabled = false; // Disable the duck collider
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = CheckIfGrounded(); // Check if the player is grounded
        HandleJump(); // Handle player jump input
        HandleDuck(); // Handle player duck input
        HandleSoundEffect(); // Handle sound effects based on player actions
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
    private void HandleJump()
    {
        // Check if the player is grounded before allowing a jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce; // Apply an upward force to the player
        }
    }

    private void HandleDuck()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            normalCollider.enabled = false; // Disable the normal collider
            duckCollider.enabled = true; // Enable the duck collider
            animator.SetBool("isDuck", true); // Set the parameter in the animator to true
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            normalCollider.enabled = true; // Enable the normal collider
            duckCollider.enabled = false; // Disable the duck collider
            animator.SetBool("isDuck", false); // Set the parameter in the animator to false
        }
    }

    private void HandleSoundEffect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.instance.PlayJumpSound(); // Play the jump sound effect
        }
        else if (isGrounded && !AudioManager.instance.HasPlayedEffectSound())
        {
           AudioManager.instance.PlayDropSound(); // Play the drop sound effect
            AudioManager.instance.SetHasPlayedEffectSound(true); // Set the effect sound played flag to true
        }
        else if (!isGrounded)
        {
            AudioManager.instance.SetHasPlayedEffectSound(false); // Set the effect sound played flag to false
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            AudioManager.instance.PlayHurtSound(); // Play the hurt sound effect
        }
    }
}
