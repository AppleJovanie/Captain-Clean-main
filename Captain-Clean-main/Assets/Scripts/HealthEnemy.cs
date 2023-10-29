using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    public static HealthEnemy Instance { get; private set; } // Use the static instance

    public int health = 5; // Initial health

    public Image[] hearts; // An array of heart images in the UI
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        // Set the static instance to this instance
        Instance = this;
        UpdateHealthBar();
    }

    // Call this function to update the health bar UI
    public void UpdateHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // You don't need this method, you can remove it.
    // public static implicit operator HealthManager(HealthEnemy v)
    // {
    //     throw new NotImplementedException();
    // }
}
