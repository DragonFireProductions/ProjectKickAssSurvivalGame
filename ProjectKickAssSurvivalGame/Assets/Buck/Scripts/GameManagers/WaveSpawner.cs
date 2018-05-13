using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    PlayerController playerHealth;

    [SerializeField]
    List<Transform> spawnLocations = new List<Transform>();

    [SerializeField]
    List<GameObject> enemyTypes = new List<GameObject>();

    public float spawnRate;

    [SerializeField]
    float spawnTimer;

    int SpawnCurrency;

    public int enemiesSpawned;

    public int daysPassed;

    DayNightCycle dayRef;

    GameObject sun;

    void Awake()
    {
        sun = GameObject.FindGameObjectWithTag("Sun");
        dayRef = sun.GetComponent<DayNightCycle>();
        daysPassed = 1;
    }
    // Update is called once per frame
    void Update ()
    {
        spawnTimer += Time.deltaTime;

        if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.PM)
        {
            if (dayRef.GetHour() >= 8f)
            {
                dayRef.SetCycle(false);
            }

            if (spawnTimer >= spawnRate)
            {
                SpawnEnemies();
            }
        }

        if (enemiesSpawned >= 10)
        {
            EndNight();

            if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.AM)
            {
                if (dayRef.GetHour() >= 6f)
                {
                    daysPassed++;
                    dayRef.SetMinuteToSecond(1f);
                    enemiesSpawned = 0;
                }
            }
        }
	}

    void SpawnEnemies()
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
    }

    void EndNight()
    {
        if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.PM)
        {
            dayRef.SetCycle(true);
            dayRef.SetMinuteToSecond(60f);
        }
    }
}
