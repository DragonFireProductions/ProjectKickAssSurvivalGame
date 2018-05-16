using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [Header("EnemySettings")]

    public Stat health;

    public int attackDamage;

    public float attackSpeed;

    //Might be used later on
    //public float attackRange;

    [HideInInspector]
    public float attackTimer;

    public float moveSpeed;

    public int spawnCost;

    public int minCoins;

    public int maxCoins;

    [Header("UnitySettings")]

    PlayerController player;

    [SerializeField]
    Transform target;

    //Retrieves targetsRefs locations at runtime
    public List<Transform> targetLocations;

    //Still dont know what im gonna do with this one
    public List<string> targetTags;

    //Must be populated within inspector
    public List<bool> targetsInRange;

    public GameObject coin;

    NavMeshAgent agent;

    Ray attackRay;

    RaycastHit attackHit;

    WaveSpawner waveSpawnerRef;

    //Accessors
    public int GetSpawnCost()
    {
        return spawnCost;
    }

    void Awake()
    {
        health.SetValues();
        player = FindObjectOfType<PlayerController>();
        waveSpawnerRef = FindObjectOfType<WaveSpawner>();
    }

    void Start()
    {

    }

    public void CheckForDamage()
    {
        if (health.CurValue == health.MaxValue)
        {
            health.bar.gameObject.SetActive(false);
        }
        else
        {
            health.bar.gameObject.SetActive(true);
        }
    }

    public void LocateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
    }

    public void Navigation()
    {
        agent.SetDestination(target.transform.position);

        agent.speed = moveSpeed;
    }

    public void UpdateTarget()
    { 

        Transform player = GameObject.FindGameObjectWithTag(targetTags[0]).transform;
        Transform fire = GameObject.FindGameObjectWithTag(targetTags[1]).transform;

        //if the list doesn't have the player in it
        //Add it once
        if (!targetLocations.Contains(player))
        {
            targetLocations.Add(player);
        }

        if (!targetLocations.Contains(fire))
        {
            targetLocations.Add(fire);
        }

    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        health.CurValue -= amount;

        //hitParticles.transform.positon = hitPoint;
        //hitPartcles.Play();

        if (health.CurValue <= 0)
        {
            Die();
        }
    }

    //When the enemies health reaches 0
    //Drop coins, and destroy the object
    public void Die()
    {
        //Randomly reward the player a number of coins from the 
        //Min and Max ints
        int reward = Random.Range(minCoins, maxCoins);

        for (int i = 0; i < reward; i++)
        {
            //Make them coins
            Instantiate(coin, transform.position, transform.rotation);
        }
        
        List<GameObject> t = waveSpawnerRef.GetEnemies();

        for (int i = 0; i < t.Count; i++)
        {
            if (gameObject.tag == "Enemy")
            {
                t.RemoveAt(i);
                break;
            }
        }
        //Destroy that baddie
        Destroy(gameObject);
    }

    public void AttackPlayer()
    {
        attackRay.origin = transform.position;
        attackRay.direction = transform.forward;

        if (Physics.Raycast(attackRay, out attackHit))
        {
            if (player.health.CurValue > 0)
            {
                player.TakeDamage(attackDamage, attackHit.point);
            }
        }
        attackTimer = 0;
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            targetsInRange[0] = true;
        }

        if (target.tag == "Fire")
        {
            targetsInRange[1] = true;
        }

        if (target.tag == "Turret")
        {
            targetsInRange[2] = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            targetsInRange[0] = false;
        }

        if (target.tag == "Fire")
        {
            targetsInRange[1] = false;
        }

        if (target.tag == "Turret")
        {
            targetsInRange[2] = false;
        }
    }

}