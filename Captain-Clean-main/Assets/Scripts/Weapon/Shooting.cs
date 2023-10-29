using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    public float cooldown = 1.0f; // Time between shots
    private float lastShotTime; // Time when the last shot was fired

    private void Update()
    {
        // Check for shooting input
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            // Check if enough time has passed since the last shot
            if (Time.time - lastShotTime >= cooldown)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    public void Shoot()
    {
        GameObject si = Instantiate(shootingItem, shootingPoint.position, Quaternion.identity);
    }
}
