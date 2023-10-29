using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForEnemy : MonoBehaviour
{
    public float life = 3;
    public float bulletSpeed = 10; // Add bullet speed variable

    private Rigidbody2D rb; // Reference to the bullet's Rigidbody2D

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        Destroy(gameObject, life);
    }

    // Allow setting the initial direction of the bullet
    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Destroy the object with the "Trap" tag
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reduce the enemy's health by 1
            HealthEnemy enemyHealth = collision.gameObject.GetComponent<HealthEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.health--;
                enemyHealth.UpdateHealthBar(); // Update the enemy's health bar
            }
        }

        // Always destroy the bullet
        Destroy(gameObject);
    }
}
