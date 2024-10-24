using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Rigidbody rb; // Rigid body of the projectile
    public float projectileForce = 8; // Force of projectile

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = transform.up * projectileForce;
        direction.y = 0;
        rb.AddForce(direction);
    }

    // Update is called once per frame
    void Update()
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