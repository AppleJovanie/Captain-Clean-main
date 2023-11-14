using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alifungor : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Enemy movement speed
    public float collisionDisableDelay = 1.0f; // Delay before re-enabling the collider
    public string playerTag = "Player"; // Tag of the player to follow

    private Transform playerTransform; // Reference to the player's transform
    private Rigidbody2D rb; // Rigidbody2D reference
    private SpriteRenderer spriteRenderer; // Reference to the enemy's SpriteRenderer
    private Collider2D enemyCollider; // Reference to the enemy's Collider2D

    private int bulletsHitCount = 0; // Number of bullets that hit the boss
    private bool isDead = false; // Flag to track if the boss is already dead
    public GameObject youWonCanvas;

    [SerializeField] private int bulletsToDestroyBoss = 15; // Number of bullets required to destroy the boss
    [SerializeField] private FloatingHealthBar healthBar;

    private Vector3 respawnPoint;


    public void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        healthBar.SetMaxHealth(bulletsToDestroyBoss);
        respawnPoint = transform.position;

        // Find the player's transform based on their tag (assuming the player has the "Player" tag)
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        if (youWonCanvas != null)
        {
            youWonCanvas.SetActive(false); // Make the Canvas inactive initially
        }
        else
        {
            Debug.LogError("Player not found with tag: " + playerTag);
        }
      
    }

    private void Update()
    {
        if (playerTransform != null && !isDead)
        {
            // Calculate the movement direction towards the player
            Vector3 movementDirection = (playerTransform.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

            // Flip the enemy sprite based on the movement direction
            spriteRenderer.flipX = (movementDirection.x < 0);
        }
    }
    //Bullet For Galisorous Boss
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SoapBullet") && !isDead)
        {
            // Decrement the boss's health
            bulletsHitCount++;
            healthBar.UpdateHealth(bulletsToDestroyBoss - bulletsHitCount);

            if (bulletsHitCount >= bulletsToDestroyBoss)
            {
                // Handle boss death
                Die();

                if (youWonCanvas != null)
                {
                    youWonCanvas.SetActive(true);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        transform.position = respawnPoint;
    }
    private void Die()
    {
        // Add any logic you want to handle the boss's death here
        // For example, you can play a death animation, trigger an event, or destroy the boss object

        Destroy(gameObject);

        // Set the flag to prevent further collisions and destruction
        isDead = true;
    }
}
