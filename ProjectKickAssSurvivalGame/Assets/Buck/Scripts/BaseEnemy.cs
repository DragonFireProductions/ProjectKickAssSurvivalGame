using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [Header("EnemyStats")]

    public float moveSpeed;

    public float maxHealth;

    float curHealth;

    public int damage;

    public float attackSpeed;

    public float attackTimer;

    public GameObject coin;

    public int minCoins;

    public int maxCoins;

    [Header("UnitySettings")]

    [SerializeField]
    Image healthBar;

    public Transform target;

    public Transform player;

    public Transform playerFire;

    NavMeshAgent agent;

    public void LocateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Fire").transform;

        curHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(target.transform.position);
    }

    //void UpdateTarget()
    //{
    //    float playerDistance = Vector3.Distance(player.transform.position, transform.position);

    //    float fireDistance = Vector3.Distance(playerFire.transform.position, transform.position);

    //    if (target != null)
    //    {
    //        if (playerDistance >= fireDistance)
    //        {
    //            target = playerFire;
    //        }

    //        else if (playerDistance < fireDistance)
    //        {
    //            target = player;
    //        }
    //    }
    //}

    public void Navigation()
    {
        RaycastHit hit;

        agent.SetDestination(target.transform.position);

        agent.speed = moveSpeed;

        if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            DestinationReached();
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }

    //This can be called from other scripts that would apply
    //Damage to the enemy
    public void TakeDamage(float amount)
    {
        curHealth -= amount;

        //sets the health to alway start at 1 and end at 0
        healthBar.fillAmount = curHealth / maxHealth;

        if (curHealth <= 0)
        {
            curHealth = 0;

            Die();
        }
    }

    public void Die()
    {
        int reward = Random.Range(minCoins, maxCoins);

        for (int i = 0; i < reward; i++)
        {
            Instantiate(coin, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    public void DestinationReached()
    {

    }
}
