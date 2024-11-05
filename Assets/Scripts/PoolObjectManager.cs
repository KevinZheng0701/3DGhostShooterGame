using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectManager : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab of the object to pool
    public int initialSize; // Initial size of the pool
    private List<GameObject> objectPool = new List<GameObject>(); // Pool of object prefabs

    // Called when script is being loaded
    private void Awake()
    {
        InitialPool();
    }

    // Function to set up the pool objects
    private void InitialPool()
    {
        // Loop through the spawn size
        for (int i = 0; i < initialSize; i++)
        {
            CreateObject(Vector3.up * 1, Quaternion.identity);
        }
    }

    // Function to create a pool object
    private GameObject CreateObject(Vector3 position, Quaternion rotation)
    {
        // Create the object and deactivate it immediately
        GameObject obj = Instantiate(objectPrefab, position, rotation);
        obj.SetActive(false);
        // Add the object to the pool and make it a child
        obj.transform.SetParent(gameObject.transform);
        objectPool.Add(obj);
        return obj;
    }

    // Function to retrieve a pool object
    public GameObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        // Loop through to find an inactive object
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeSelf)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                return obj; // Return the pool object
            }
        }
        GameObject newObject = CreateObject(position, rotation);
        return newObject; // Return the newly created object
    }

    // Function to put back pool objects
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}