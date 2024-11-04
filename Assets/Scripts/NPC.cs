using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float moveSpeed; // Movement speed of the NPC
    public int damage; // Damage the enemy do
    public float cooldown; // Time of the cooldown
    public float timer; // Time of the cooldown
    public Rigidbody rb; // Rigid body
    public GameObject targetPlayer; // The target to move towards
    public PlayerController playerControllerScript; // Reference to the player controller script

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = targetPlayer.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 directionToPlayer = (targetPlayer.transform.position - transform.position).normalized;
        Vector3 moveDirection = directionToPlayer * moveSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.LookRotation(directionToPlayer); // Rotate towards player
        transform.position += moveDirection; // Move towards player
    }

    private void OnEnterCollision(Collision collision)
    {
        Attack(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        Attack(collision.gameObject);
    }

    private void Attack(GameObject obj)
    {
        if (obj.CompareTag("Player") && timer <= 0)
        {
            timer = cooldown; // Reset cooldown timer
            playerControllerScript.TakeDamage(damage);
        }
    }
}
