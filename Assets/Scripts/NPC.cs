using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public GameObject targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        float deltaX = targetPlayer.transform.position.x - transform.position.x;
        float deltaZ = targetPlayer.transform.position.z - transform.position.z;
        Vector3 direction = new Vector3(deltaX, 0, deltaZ).normalized * moveSpeed;
        transform.position += direction;
    }

    private void OnEnterCollision(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("YOU LOSE");
        }
    }
}
