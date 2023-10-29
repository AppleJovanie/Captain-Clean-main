using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScriptShoot : MonoBehaviour
{
    public Transform shootingPointer;
    public GameObject shootingObject;
    public float bulletSpeed = 3;
    public float cooldownDuration = 1.0f;
    private float lastShotTime; 

    public void TryToShoot()
    {
        if (Time.time - lastShotTime < cooldownDuration)
            return;

        var bullet = Instantiate(shootingObject, shootingPointer.position, transform.rotation);

        // Calculate the direction from the player to the shootingPointer
        Vector2 shootDirection = (shootingPointer.position - transform.position).normalized;

        // Set the velocity of the bullet to shoot horizontally
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletSpeed, 0);
        lastShotTime = Time.time;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Destroy the object with the "Trap" tag
            Destroy(collision.gameObject);
        }
        
    }
}

