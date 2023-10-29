using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 2; // Maximum health of the boss
    private int currentHealth; // Current health of the boss

    public GameObject youWonCanvas; // Reference to the Canvas containing the "YouWon" panel

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
        if (youWonCanvas != null)
        {
            youWonCanvas.SetActive(false); // Make the Canvas inactive initially
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;

            // Check if the boss has been destroyed
            if (currentHealth <= 0)
            {
                // Perform any additional logic when the boss is destroyed (e.g., play an explosion animation, trigger an event, etc.)
                DestroyBoss();

                // Enable the "YouWon" Canvas
                if (youWonCanvas != null)
                {
                    youWonCanvas.SetActive(true);
                }
            }
        }
    }

    public void DestroyBoss()
    {
        Destroy(gameObject); // Destroy the boss object
    }
}
