using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    private int bulletsHitBoss = 0;
    public int bulletsToDestroyBoss = 2; // Number of bullets required to destroy the boss

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Destroy objects tagged as "Trap"
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            bulletsHitBoss++;

            // Check if enough bullets have hit the boss
            if (bulletsHitBoss >= bulletsToDestroyBoss)
            {
                // Notify the boss that it's been destroyed
                collision.gameObject.GetComponent<BossHealth>().TakeDamage();
            }
        }

        // Always destroy the bullet
        Destroy(gameObject);
    }
}
