using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] spawnPositions;
    public float spawnInterval;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

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

    // Function to spawn at one of the four points
    private Vector3 GetRandomSpawnPosition()
    {
        int index = Random.Range(0, spawnPositions.Length);
        return spawnPositions[index].position;
    }
}
