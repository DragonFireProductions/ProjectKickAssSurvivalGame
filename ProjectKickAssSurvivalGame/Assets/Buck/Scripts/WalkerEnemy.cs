using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerEnemy : BaseEnemy
{

    void Start()
    {
        playerFire = GameObject.FindGameObjectWithTag("Fire").transform;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        LocateTarget();
    }

    void Update()
    {
        UpdateTarget();
        Navigation();
    }

    void UpdateTarget()
    {
        attackTimer+= Time.deltaTime;

        float playerDistance = Vector3.Distance(player.transform.position, transform.position);

        float fireDistance = Vector3.Distance(playerFire.transform.position, transform.position);

        if (target != null)
        {
            if (playerDistance >= fireDistance)
            {
                target = playerFire;

                if (fireDistance <= 0.5f)
                {
                    //Attack();
                }
            }

            else if (playerDistance < fireDistance)
            {
                target = player;

                if (playerDistance <= 1f)
                {
                    if (attackTimer > attackSpeed)
                    {
                        Attack(target);
                        attackTimer = 0.0f;
                    }
                }
            }
        }
    }

    void Attack(Transform player)
    {
        PlayerController p = player.GetComponent<PlayerController>();

        //If the player has the player script
        //Do the stuff
        if (p != null)
        {
            //Passes through the damage to the take damage function within
            //The player script
            p.TakeDamage(damage);
        }
    }
}
