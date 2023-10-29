using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health; // Initial health

    public Image[] hearts; // An array of heart images in the UI
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private Rigidbody2D rb;
    private Animator anim;

    public static HealthManager Instance { get; private set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
        health = 3; // Initialize health
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

    public static implicit operator HealthManager(HealthEnemy v)
    {
        throw new NotImplementedException();
    }
}
