using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool debug;
    public float speed;
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
    }

    // Function to move the player
    private Vector3 Direction()
    {
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
}
