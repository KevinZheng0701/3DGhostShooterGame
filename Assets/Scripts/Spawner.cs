using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolObjectManager objectPool; // Pool to get the object
    public Transform[] spawnPositions; // Array of spawn points
    public float spawnInterval = 5f; // Time between spawns in seconds
    private float spawnTimer; // Tracks time since last spawn

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0;
        }
    }

    // Spawn the object at a random position from the array
    private void SpawnObject()
    {
        GameObject obj = objectPool.GetFromPool(GetRandomSpawnPosition(), Quaternion.identity);
        obj.SetActive(true);
    }

    // Select a random spawn point from the list
    private Vector3 GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);
        return spawnPositions[randomIndex].position;
    }
}