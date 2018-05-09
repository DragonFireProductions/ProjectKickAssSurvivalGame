using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        playerFire = GameObject.FindGameObjectWithTag("Fire").transform;

        curHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        fire = GameObject.FindGameObjectWithTag("Fire");
        fireHealth = fire.GetComponent<FireHealth>();

        enemyHealth = GetComponent<BaseEnemy>();
    }


    void Start()
    {
        LocateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        UpdateTarget();
        Navigation();

        if (attackTimer >= attackSpeed && playerInRange && enemyHealth.curHealth > 0)
        {
            AttackPlayer();
        }

        if (attackTimer >= attackSpeed && fireInRange && enemyHealth.curHealth > 0)
        {
            AttackFire();
        }
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            playerInRange = true;
        }

        if (target.tag == "Fire")
        {
            fireInRange = true;
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            playerInRange = false;
        }

        if (target.tag == "Fire")
        {
            fireInRange = false;
        }
    }
}
