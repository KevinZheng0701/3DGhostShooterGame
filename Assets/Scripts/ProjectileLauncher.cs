using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab; // Get projectile gameobject
    public Transform playerTransform; // Transform of the player
    public Transform launchPoint; // Position of the launch point
    public float cooldown; // Time of the cooldown
    private float cooldownCount; // Timer between next fire

    // Update is called once per frame
    void Update()
    {
        if (cooldownCount > 0) // Cooldown timer is positive so cannot shoot
        {
            cooldownCount -= Time.deltaTime; // Decrease cooldown time
        }
        else
        {
            ShootProjectile(); // Allows shooting
        }
    }

    // Allows the player to shoot projectiles
    private void ShootProjectile()
    {
        if (Input.GetAxis("Fire1") == 1) // Detects left mouse button click
        {
            Instantiate(projectilePrefab, launchPoint.position, transform.rotation); // Spawn the projectile
            cooldownCount = cooldown; // Set the cooldown timer
        }
    }
}