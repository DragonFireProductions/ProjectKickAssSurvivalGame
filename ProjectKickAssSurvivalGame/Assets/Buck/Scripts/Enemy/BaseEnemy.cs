using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [Header("EnemyStats")]

    public float moveSpeed;

    public int attackDamage;

    public float attackSpeed;

    //[HideInInspector]
    public float attackTimer;

    public bool playerInRange;
    bool fireInRange;

    [Header("UnitySettings")]


    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public Transform playerFire;

    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    FireHealth fireHealth;


    NavMeshAgent agent;

    public void LocateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Fire").transform;

        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(target.transform.position);
    }

    public void Navigation()
    {
        RaycastHit hit;

        agent.SetDestination(target.transform.position);

        agent.speed = moveSpeed;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }

}
