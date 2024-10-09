using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Direction();
        rb.AddForce(direction * speed);
    }

    private Vector3 Direction()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical);
    }
}
