using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 8; // Speed of projectile
    public float projectileLife = 10; // Lifetime of the projectile
    private float projectileCount; // Timer for the projectile

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (projectileCount < projectileLife)
        { // Projectile is still alive
            projectileCount += Time.deltaTime; // Reduce the lifetime of the projectile
        }
        else
        { // Timer is up
            Destroy(gameObject); // Projectile is gone
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Check for collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") // Collide with enemy objects
        {
            Destroy(collision.gameObject); // Destroy the damage object
        }
        Destroy(gameObject); // Destroy the projectile
    }
}