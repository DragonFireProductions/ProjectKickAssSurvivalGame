using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [Header("EnemySettings")]

    public float attackDamage;

    public float attackSpeed;

    [HideInInspector]
    public float attackTimer;

    public float moveSpeed;

    public float maxHealth;

    [HideInInspector]
    public float curHealth;

    public int minCoins;

    public int maxCoins;

    [Header("UnitySettigns")]

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public PlayerHealth playerHealth;

    [HideInInspector]
    public GameObject fire;
    [HideInInspector]
    public FireHealth fireHealth;

    [HideInInspector]
    public BaseEnemy enemyHealth;

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public Transform playerTransform;

    [HideInInspector]
    public Transform playerFire;

    [HideInInspector]
    public bool playerInRange;
    [HideInInspector]
    public bool fireInRange;
    [HideInInspector]
    public bool turretInRange;

    [SerializeField]
    Image healthBar;

    public GameObject coin;

    NavMeshAgent agent;

    public void LocateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Fire").transform;

        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(target.transform.position);
    }

    public void Navigation()
    {
        agent.SetDestination(target.transform.position);

        agent.speed = moveSpeed;
    }

    public void UpdateTarget()
    {
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);

        float fireDistance = Vector3.Distance(playerFire.position, transform.position);

        if (target != null)
        {
            if (playerDistance >= fireDistance)
            {
                target = playerFire;
            }

            if (playerDistance < fireDistance)
            {
                target = playerTransform;
            }
        }
    }

    //This can be called from other scripts that would apply
    //Damage to the enemy
    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        curHealth -= amount;

        //sets the health to alway start at 1 and end at 0
        healthBar.fillAmount = curHealth / maxHealth;

        //hitParticles.transform.positon = hitPoint;
        //hitPartcles.Play();

        if (curHealth <= 0)
        {
            curHealth = 0;

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
        //Destroy that baddie
        Destroy(gameObject);
    }

    public void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if (playerHealth.curHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        attackTimer = 0f;
    }

    public void AttackFire()
    {
        attackTimer += Time.deltaTime;

        if (fireHealth.curHealth > 0)
        {
            fireHealth.TakeDamage(attackDamage);
        }

        attackTimer = 0f;
    }
}
