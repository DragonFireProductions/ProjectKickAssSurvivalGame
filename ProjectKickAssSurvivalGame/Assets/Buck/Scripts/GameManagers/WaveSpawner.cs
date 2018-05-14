using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyTypes;

    [SerializeField]
    List<Transform> spawnLocations;

    [SerializeField]
    List<GameObject> spawnedEnemies;

    DayNightCycle dayRef;

    [SerializeField]
    int spawnCurrency;

    [SerializeField]
    float spawnRate;

    float spawnTimer;

    bool nightComplete;

    void Awake()
    {
        dayRef = FindObjectOfType<DayNightCycle>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (!nightComplete)
        {
            if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.PM)
            {
                if (dayRef.GetHour() == 8)
                {
                    SetNightSpawnCurrency();

                    dayRef.SetCycle(false);

                    if (spawnTimer >= spawnRate)
                    {
                        SpawnWave();
                    }
                }
            }
        }

        if (spawnCurrency <= 0)
        {
            EndNight();

            if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.AM)
            {
                if (dayRef.GetHour() >= 6)
                {
                    dayRef.SetMinuteToSecond(1.0f);
                    nightComplete = false;
                }
            }
        }
    }

    void SetNightSpawnCurrency()
    {
        spawnCurrency = Mathf.RoundToInt(15 * dayRef.GetDaysPassed() * 0.75f);
    }

    void SpawnWave()
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

        spawnedEnemies.Add(selectedEnemy);

        if (spawnedEnemies != null)
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i].GetComponent<BaseEnemy>() != null)
                {
                    spawnCurrency -= spawnedEnemies[i].GetComponent<BaseEnemy>().spawnCost;
                }
            }
        }

        spawnTimer = 0;
    }

    void EndNight()
    {
        nightComplete = true;

        //Need to figure out the for loop for this
        //if (spawnedEnemies == null)
        //{
            if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.PM)
            {
                dayRef.SetCycle(true);
                dayRef.SetMinuteToSecond(60f);
            }
        //}
    }
}
