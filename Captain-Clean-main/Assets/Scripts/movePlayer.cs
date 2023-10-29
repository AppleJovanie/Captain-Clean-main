using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    public float speed;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;
    public float jumpSpeed = 5;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        Movement();
    }

    // Function to make the character face right
    public void Right()
    {
        // Set the rotation to (0, 0, 0) for facing right
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Function to make the character face left
    public void Left()
    {
        // Set the rotation to (0, 180, 0) for facing left
        transform.rotation = Quaternion.Euler(0, 180, 0);
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

}