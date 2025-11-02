using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject cratePrefab;  
    public float spawnInterval = 2f;
    public float spawnRangeX = 8f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCrate();   // Spawn a new crate every interval
            timer = 0f;
        }
    }

    void SpawnCrate()
    {
        // Create random spawn pos and instantiate crate
        float xPosition = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(xPosition, 6f, 0f);
        GameObject crate = Instantiate(cratePrefab, spawnPosition, Quaternion.identity);

        // Assign random value between 3 and 10
        int randomValue = Random.Range(3, 10);
        crate.GetComponent<Crate>().crateValue = randomValue;
    }
}
