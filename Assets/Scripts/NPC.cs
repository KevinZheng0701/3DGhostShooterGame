using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float moveSpeed;
    public int damage; // Damage the enemy do
    public float cooldown; // Time of the cooldown
    public float timer; // Time of the cooldown
    public Rigidbody rb;
    public GameObject targetPlayer;
    public PlayerController playerControllerScript;

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
        float deltaX = targetPlayer.transform.position.x - transform.position.x;
        float deltaZ = targetPlayer.transform.position.z - transform.position.z;
        Vector3 direction = new Vector3(deltaX, 0, deltaZ).normalized * moveSpeed;
        transform.position += direction;
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
            timer = cooldown;
            playerControllerScript.TakeDamage(damage);
        }
    }
}
