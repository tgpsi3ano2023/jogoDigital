using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;

    // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    public Vector3 spawnPosition;

    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {
        //spawnPosition.x = Random.Range(-17, 17);
        //spawnPosition.y = 0.5f;
        //spawnPosition.z = Random.Range(-17, 17);

        Instantiate(objects[objects.Length - 1], spawnPosition, Quaternion.identity);
    }
}