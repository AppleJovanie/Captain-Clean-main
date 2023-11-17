using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectorScript : MonoBehaviour
{
    public List<Button> buttonsToInteract;
    [SerializeField] private AudioSource almanacRick;

    // Track collected coins
    private HashSet<GameObject> collectedCoins = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin") && !collectedCoins.Contains(collision.gameObject))
        {
            almanacRick.Play();
            ActivateNextButton();
            collectedCoins.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    private void ActivateNextButton()
    {
        foreach (Button button in buttonsToInteract)
        {
            if (!button.interactable)
            {
                button.interactable = true;
                break; // Stop after making the first inactive button interactable
            }
        }
    }

    // Method to handle coin interaction when the player respawns
    public void HandleRespawn()
    {
        // Check if all required coins have been collected before making buttons interactable
        bool allCoinsCollected = true;
        foreach (Button button in buttonsToInteract)
        {
            if (!collectedCoins.Contains(button.gameObject))
            {
                allCoinsCollected = false;
                break;
            }
        }

        // Make buttons interactable only if all required coins have been collected
        if (allCoinsCollected)
        {
            foreach (Button button in buttonsToInteract)
            {
                if (!button.interactable)
                {
                    button.interactable = true;
                    break;
                }
            }
        }
    }
}
