using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementChar : MonoBehaviour
{
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    public float jumpSpeed = 5;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource running;
    [SerializeField] private AudioSource die;
    
    public bool isRunning = false;
    private bool canJump = true;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    //public GameObject youWon;
    private bool insideFallSideCollider = false;
    private enum MovementState {idle, running, jumping ,falling }
   MovementState state;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnPoint = transform.position;     
    }

    void Update()
    {
        Movement(); 
        fallDetector.transform.position = new Vector2(transform.position.x,fallDetector.transform.position.y);
        anim.SetInteger("state", (int)state);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
           
        if (collision.tag == "FallSideDetector")
        {
            insideFallSideCollider = true;
            Debug.Log("Collided FallSide");
            moveLeft = false;
            moveRight = false;
            canJump = false;
        }
        { 
            
        }

        if (collision.tag == "FallDetector")
        {
            Die();
            Respawn();
        }
        
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FallSideDetector")
        {
            Debug.Log("Exited FallSide");
            insideFallSideCollider = false;
        }
      
    }
    private void Respawn()
    {
        transform.position = respawnPoint;
    }
    private void Die()
    {
       
        HealthManager.health--;
        HealthManager.Instance.UpdateHealthBar();

        if (HealthManager.health <= 0)
        {
            anim.SetTrigger("death");
        }

    }
    public void MoveLeft()
    {
        if (moveLeft == true)
        {
            running.Play();
            transform.rotation = Quaternion.Euler(0, 180, 0);
            state = MovementState.running; // Start running animation when moving left}
        }
        else
        {
            CheckMovementState();
        }
        
    }
    public void MoveRight()
    {
        if (moveRight == true)
        {
            running.Play();
            transform.rotation = Quaternion.Euler(0, 0, 0);
            state = MovementState.running;
        }
        else
        {
            moveRight = false;
            CheckMovementState(); // Stop running animation when not moving right
        }
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
        MoveLeft();
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
        CheckMovementState();
    }

    public void pointerDownRight()
    {
        moveRight = true;
        MoveRight();
    }

    public void pointerUpRight()
    {
        moveRight = false;
        CheckMovementState();
    } 

    void Movement()
    {
        if (insideFallSideCollider)
        {
            // Player is inside the FallSideDetector, disable jump
            canJump = false;
        }
        if (moveLeft)
        {
            horizontalMove = -speed;
            state = MovementState.running; // Start running animation when moving left
        }
        else if (moveRight)
        {
            horizontalMove = speed;
            state = MovementState.running; // Start running animation when moving right
        }
        else
        {
            horizontalMove = 0;
            state = MovementState.idle; // Stop running animation when not moving
        }

        if (rb.velocity.y == 0 && (moveLeft || moveRight))
        {
            state = MovementState.running; // Keep running animation when moving right or left on the ground
        }
    }


    private void CheckMovementState()
    {
        if (!moveLeft && !moveRight)
        {
            state = MovementState.idle; // Stop running animation when no movement
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0f);
        return hit.collider != null;
    }

    public void jumpButton()
    {
        if (IsGrounded() && canJump && !insideFallSideCollider)
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.up * jumpSpeed;
            state = MovementState.jumping;
            canJump = false;
        }

    }
     
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = movement;

        // Check if the player is on the ground and allow jumping
        if (rb.velocity.y == 0)
        {
            canJump = true;
        }
        
    }
}
