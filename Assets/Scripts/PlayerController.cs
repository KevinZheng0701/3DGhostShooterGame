using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool debug;
    public float speed;
    public float jumpForce;
    public bool isJumping;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (debug)
        {
            Vector3 dir = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
            Debug.DrawRay(transform.position, dir * 2f, Color.red);
            Debug.DrawRay(transform.position, rb.velocity, Color.yellow);
            Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.black);
            Debug.DrawRay(transform.position + Vector3.up, transform.right, Color.blue);
        }
        return new Vector3(horizontal, 0, vertical);
    }

    // Function to make the player jump
    private void Jump()
    {
        float jump = Input.GetAxis("Jump"); // Get jump input
        if (jump == 1)
        {
            isJumping = true;
            rb.velocity = Vector3.zero; // Reset the momentum from the previous jump
            rb.AddForce(new Vector3(0, jump, 0) * jumpForce, ForceMode.Impulse); // Add force to make the player jump
        }
    }

    // Make the player reset the jump after touching an object
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
