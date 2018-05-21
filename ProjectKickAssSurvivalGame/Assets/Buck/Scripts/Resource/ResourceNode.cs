using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public bool inRange;
    bool isSpawned = true;

    public int resourceHealth;

    public int minResource, maxResource;

    public float respawnTime;
    float respawnTimer;

    public GameObject resourcePrefab;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        DamageResource();
        RespawnCheck();
	}

    void RespawnCheck()
    {
        if (resourceHealth <= 0 && isSpawned)
        {
            isSpawned = false;
            respawnTimer += Time.deltaTime;

            if (respawnTimer >= respawnTime && !isSpawned)
            {
                gameObject.SetActive(true);
                isSpawned = true;
            }
        }
    }

    void DamageResource()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            resourceHealth--;

            if (resourceHealth <= 0)
            {
                ResourceDestroyed();
            }
        }
        else
            return;
    }

    void ResourceDestroyed()
    {
        int resourceReward = Random.Range(minResource, maxResource);

        resourceHealth = 0;

        gameObject.SetActive(false);

        for (int r = 0; r < resourceReward; r++)
        {
            Instantiate(resourcePrefab, transform.position, transform.rotation);
        }
    }



    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
            inRange = true;
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
            inRange = false;
    }
}
