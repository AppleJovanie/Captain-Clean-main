using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{
    public UnityEvent action;

    public float moveSpeed = 3.0f; // Enemy movement speed
    public float collisionDisableDelay = 1.0f; // Delay before re-enabling the collider

    private Rigidbody2D rb; // Rigidbody2D reference
    private SpriteRenderer spriteRenderer; // Reference to the enemy's SpriteRenderer
    private Collider2D enemyCollider; // Reference to the enemy's Collider2D
    private int walkingDirection = 1; // 1 for right, -1 for left
    private Vector3 respawnPoint;
  

    public bool canDealDamage = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        respawnPoint = transform.position;

    }

    public void Action()
    {
        action?.Invoke();
    }

    private void Update()
    {
        // Move the enemy in the current walking direction
        transform.Translate(Vector2.right * walkingDirection * moveSpeed * Time.deltaTime);

        // Flip the enemy sprite based on the walking direction
        spriteRenderer.flipX = (walkingDirection == -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && canDealDamage)
        {
           
            enemyCollider.enabled = false;
            canDealDamage = false;
            

            // Re-enable the collider after a delay
            StartCoroutine(EnableColliderAfterDelay(collisionDisableDelay));
        }
        else if (collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("Boss") || collision.transform.CompareTag("Trap")){
            // Change the walking direction when colliding with an obstacle
            walkingDirection *= -1;
        }
    }
    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyCollider.enabled = true;
        canDealDamage = true;
    }
}
