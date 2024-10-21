using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform playerTransform;
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

    private void SpawnObject()
    {
        Instantiate(objectPrefab, GetRandomPositionAroundPlayer(), Quaternion.identity);
    }

    private Vector3 GetRandomPositionAroundPlayer()
    {
        Vector3 position = Vector3.zero;
        float left = Random.Range(0, 2);
        float up = Random.Range(0, 2);
        if (left == 0)
        {
            position.x = Random.Range(playerTransform.position.x - 20, playerTransform.position.x);
        } else
        {
            position.x = Random.Range(playerTransform.position.x, playerTransform.position.x + 20);
        }
        if (up == 0)
        {
            position.z = Random.Range(playerTransform.position.z - 20, playerTransform.position.z);
        } else
        {
            position.z = Random.Range(playerTransform.position.z, playerTransform.position.z + 20);
        }
        timer = 0;
        return position;
    }
}
