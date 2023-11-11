using System.Collections;
using System.Collections.Generic;
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
    public bool isRunning = false;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public GameObject youWon;
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
    //private void ShowGameOverUI()
    //{
    //    youWon.SetActive(true); // Set the reference to your "Game Over" UI element here
    //    Time.timeScale = 0f; // Pause the game by setting time scale to 0
    //}
 
    void Update()
    {
        Movement();
       
        fallDetector.transform.position = new Vector2(transform.position.x,fallDetector.transform.position.y);
        anim.SetInteger("state", (int)state);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            // Reset the object's position to the respawn point
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            PlayerPrefs.SetInt("CheckpointReached", 1);
            PlayerPrefs.Save();
            respawnPoint = transform.position;
        }
      
        //// Finish Line
        //else if (collision.gameObject.CompareTag("FinishLine"))
        //{
        //    ShowGameOverUI();
        //}    
    }
 

    public void pointerDownLeft()
    {
        running.Play();
        transform.rotation = Quaternion.Euler(0, 180, 0);
        moveLeft = true;
        state = MovementState.running; // Start running animation when moving left

    }

    public void pointerUpLeft()
    {
        moveLeft = false;
        state = MovementState.idle; // Stop running animation when not moving left
    }

    public void pointerDownRight()
    {
        running.Play();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        moveRight = true;      
        state = MovementState.running;
       
    }
   
    public void pointerUpRight()
    {
        moveRight = false;
        state = MovementState.idle; // Stop running animation when not moving right
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void jumpButton()
    {
        Debug.Log("Jump button clicked");
        if (rb.velocity.y == 0)
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.up * jumpSpeed;
            state = MovementState.jumping;
        }  
    }


    private void FixedUpdate()
    {
  

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
