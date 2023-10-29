using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Trap"))
        {
            Debug.Log("Player Collided to enemy");
            HealthManager.health--;
          

            // Check if the player has run out of health
            if (HealthManager.health <= 0)
            {
                // Player has lost the game, implement game over logic here
                // For example, you can show a game over screen or restart the level.
                // You may need to add additional game over logic depending on your game.
            }
        }
    }
}
