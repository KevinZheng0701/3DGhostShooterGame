using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform playerTransform;
    public Transform topTransform;
    public Transform rightTransform;
    public Transform bottomTransform;
    public Transform leftTransform;
    public float spawnInterval;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnInterval)
        {
            SpawnObject();
        }
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    // Function to spawn the object
    private void SpawnObject()
    {
        Instantiate(objectPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        timer = 0;
    }

    /*
    private Vector3 GetRandomPositionAroundPlayer()
    {
        Vector3 position = Vector3.up; // Set to the center with one unit up in the y direction
        // Get left, right, up, and down sector
        float left = Random.Range(0, 2);
        float up = Random.Range(0, 2);
        if (left == 1) // Spawn left
        {
            position.x = Random.Range(playerTransform.position.x - 20, playerTransform.position.x - 10);
        } else // Spawn right
        {
            position.x = Random.Range(playerTransform.position.x + 10, playerTransform.position.x + 20);
        }
        if (up == 1) // Spawn up
        {
            position.z = Random.Range(playerTransform.position.z + 10, playerTransform.position.z + 20);
        }
        else // Spawn down
        {
            position.z = Random.Range(playerTransform.position.z - 20, playerTransform.position.z - 10);
        }
        return position;
    }*/

    // Function to spawn at one of the four points
    private Vector3 GetRandomSpawnPosition()
    {
        float index = Random.Range(0, 5);
        if (index == 0)
        {
            return topTransform.position;
        } else if (index == 1)
        {
            return rightTransform.position;
        } else if (index == 2)
        {
            return bottomTransform.position;
        } else
        {
            return leftTransform.position;
        }
    }
}
