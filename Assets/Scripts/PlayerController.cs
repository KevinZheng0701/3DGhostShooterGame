using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping;
    public Rigidbody rb;
    private int health;
    public int maxHealth;
    public AudioSource damageSoundEffect;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.SetUpHealth();
        health = maxHealth;
    }

    void FixedUpdate()
    {
        Vector3 dir = transform.TransformDirection(Direction() * speed);
        rb.AddForce(dir);
        if (!isJumping)
        {
            Jump();
        }
    }

    // Function to move the player
    private Vector3 Direction()
    {
        // Get the WASD and arrow direction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical);
    }

    // Function to make the player jump
    private void Jump()
    {
        float jump = Input.GetAxis("Jump"); // Get jump input
        if (jump == 1)
        {
            isJumping = true;
            rb.AddForce(new Vector3(0, jump, 0) * jumpForce, ForceMode.Impulse); // Add force to make the player jump
        }
    }

    // Make the player reset the jump after touching an object
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        damageSoundEffect.Play();
        gameManager.ReportHealth(health, maxHealth);
    }
}
