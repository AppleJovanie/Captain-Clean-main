using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private float maxHealth; // Maximum health value

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        slider.maxValue = health;
        slider.value = health; // Set the initial value to the maximum health
    }

    public void UpdateHealth(float currentHealth)
    {
        slider.value = currentHealth; // Update the health bar value
    }
}
