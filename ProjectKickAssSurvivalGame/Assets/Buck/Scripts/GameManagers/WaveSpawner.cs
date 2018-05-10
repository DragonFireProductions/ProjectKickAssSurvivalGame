using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    PlayerHealth playerHealth;

    [SerializeField]
    List<Transform> spawnLocations = new List<Transform>();

    [SerializeField]
    List<GameObject> enemyTypes = new List<GameObject>();

    public float spawnRate;

    [SerializeField]
    float spawnTimer;

    public int enemiesSpawned;

    public bool isNight;
    // Update is called once per frame
    void Update ()
    {
        spawnTimer += Time.deltaTime;

        if (isNight)
        {
            if (spawnTimer >= spawnRate)
            {
                SpawnEnemies();
            }
        }
	}

    void SpawnEnemies()
    {
        if (isNight)
        {
            //Select a spawn location from the list of locations
            Transform currentSpawn = spawnLocations[Random.Range(0, spawnLocations.Count)];
            //Store the position of the chosen location
            Vector3 currentSpawnPosition = currentSpawn.position;
            //And its rotation
            Quaternion currentSpawnRotation = currentSpawn.rotation;
            //select an enemy from the list of enemies
            GameObject selectedEnemy = enemyTypes[Random.Range(0, enemyTypes.Count)];
            //Create the baddie
            Instantiate(selectedEnemy, currentSpawnPosition, currentSpawnRotation);

            spawnTimer = 0;

            enemiesSpawned++;

            if (enemiesSpawned == 10)
            {
                EndNight();
            }
        }
    }

    void EndNight()
    {
        isNight = false;
        enemiesSpawned = 0;
    }
}
