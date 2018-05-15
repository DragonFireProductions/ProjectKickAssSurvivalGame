using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{

    void Start()
    {
        LocateTarget();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        UpdateTarget();
        Navigation();
        CheckForDamage();

        if (attackTimer >= attackSpeed && targetsInRange[0] == true && health.CurValue > 0)
        {
            AttackPlayer();
        }
    }
}
