using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float jumpForce = 10.0f; // Adjust the jump force as needed
    private Rigidbody2D rb;
    private bool isGrounded = true;
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is touching the ground (you can use a more advanced check here)
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Check if the jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
