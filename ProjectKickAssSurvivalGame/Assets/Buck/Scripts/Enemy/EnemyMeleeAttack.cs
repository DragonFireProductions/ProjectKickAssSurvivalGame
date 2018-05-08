﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public bool playerInRange;
    bool fireInRange;

    [SerializeField]
    float attackDamage;

    [SerializeField]
    float attackSpeed;

    public float attackTimer;

    GameObject player;
    PlayerHealth playerHealth;

    GameObject fire;
    FireHealth fireHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        fire = GameObject.FindGameObjectWithTag("Fire");
        fireHealth = fire.GetComponent<FireHealth>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackSpeed && playerInRange)
        {
            AttackPlayer();
        }

        if (attackTimer >= attackSpeed && fireInRange)
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
