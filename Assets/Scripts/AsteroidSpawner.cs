using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidObjects;
    public int amountAsteroidsToSpawn = 10;
    public float minRandomSpawn = -500;
    public float maxRandomSpawn = 500;
    
    private void Start()
    {
        SpawnAsteroid();
    }
    // Spawns random asteroids on the box
    void SpawnAsteroid()
    {
        for (int i = 0; i < amountAsteroidsToSpawn; i++)
        {
            float randomX = Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomY = Random.Range(minRandomSpawn, maxRandomSpawn);
            float randomZ = Random.Range(minRandomSpawn, maxRandomSpawn);
            Vector3 randomSpawnPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);
            GameObject tempObj = Instantiate(asteroidObjects[Random.Range(0,3)], randomSpawnPoint, Quaternion.identity);
            tempObj.transform.parent = this.transform;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxRandomSpawn * 2, maxRandomSpawn * 2, maxRandomSpawn * 2));
    }
}