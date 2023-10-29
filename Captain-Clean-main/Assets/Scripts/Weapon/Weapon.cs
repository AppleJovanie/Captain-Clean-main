using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int totalWeapons = 1;

    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    public Transform shootingPointer;
    public GameObject[] shootingObjects; // An array of different bullets or shooting objects
    public float bulletSpeed = 3;
    public float cooldownDuration = 1.0f;
    private float lastShotTime;
    [SerializeField] private AudioSource shoot;
    [SerializeField] private AudioSource switchWeapon;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon(true); // Switch to the next weapon
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon(false); // Switch to the previous weapon
        }
    }

    public void SwitchWeapon(bool nextWeapon)
    {
        switchWeapon.Play();
        // Deactivate the current weapon
        guns[currentWeaponIndex].SetActive(false);

        if (nextWeapon)
        {
            // Switch to the next weapon and loop to the start if necessary
            currentWeaponIndex = (currentWeaponIndex + 1) % totalWeapons;
        }
        else
        {
            // Switch to the previous weapon and loop to the end if necessary
            currentWeaponIndex = (currentWeaponIndex - 1 + totalWeapons) % totalWeapons;
        }

        // Activate the new weapon
        guns[currentWeaponIndex].SetActive(true);
        currentGun = guns[currentWeaponIndex];
    }

    public void TryToShoot()
    {
        
        if (Time.time - lastShotTime < cooldownDuration)
            return;

        // Check if there are shooting objects available for the current weapon
        if (currentWeaponIndex < shootingObjects.Length && shootingObjects[currentWeaponIndex] != null)
        {
            shoot.Play();
            var bullet = Instantiate(shootingObjects[currentWeaponIndex], shootingPointer.position, transform.rotation);

            // Calculate the direction from the player to the shootingPointer
            Vector2 shootDirection = (shootingPointer.position - transform.position).normalized;

            // Set the velocity of the bullet to shoot horizontally
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletSpeed, 0);

            lastShotTime = Time.time;
        }
    }
}