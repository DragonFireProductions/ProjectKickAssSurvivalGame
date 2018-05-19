using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{

    void Start()
    {
    }

    void Update()
    {
        CheckForTargets();
        CheckForDamage();

        if (targetsInRange[0] == true)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackSpeed && targetsInRange[0] == true && health.CurValue > 0)
            {
                AttackPlayer();
            }
        }
    }
}
