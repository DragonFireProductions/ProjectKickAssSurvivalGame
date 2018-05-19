using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseEnemy : EnemyTargetManager
{
    [Header("EnemySettings")]

    public Stat health;

    public int attackDamage;
    public float attackSpeed;
    [HideInInspector]
    public float attackTimer;
    //Might be used later on
    //public float attackRange;

    public float moveSpeed;

    public int spawnCost;

    public int minCoins;
    public int maxCoins;

    [Header("UnitySettings")]

    PlayerController player;
    WaveSpawner waveSpawnerRef;
    //EnemyTargetManager targetManager;

    public List<Transform> wayPoints;
    int wayPointIndex = 0;

    [SerializeField]
    Transform curTarget;
    //Must be populated within inspector
    public List<bool> targetsInRange;

    public GameObject coin;

    Transform myPos;
    NavMeshAgent agent;

    Ray attackRay;
    RaycastHit attackHit;

    //Accessors
    public int GetSpawnCost()
    {
        return spawnCost;
    }

    void Awake()
    {
        health.SetValues();
        player = FindObjectOfType<PlayerController>();
        //targetManager = FindObjectOfType<EnemyTargetManager>();
        agent = GetComponent<NavMeshAgent>();
        myPos = transform;
        agent.speed = moveSpeed;
    }

    void Start()
    {
        //if (targetManager != null)
        //{
        //    targetManager.AddTarget(transform);
        //}
        AddAllTargets();
        //AddTarget(transform);
    }

    void OnDestroy()
    {
        //if (targetManager != null)
        //{
        //    targetManager.RemoveTarget(transform);
        //}
        RemoveTarget(transform);
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

    public void CheckForTargets()
    { 

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