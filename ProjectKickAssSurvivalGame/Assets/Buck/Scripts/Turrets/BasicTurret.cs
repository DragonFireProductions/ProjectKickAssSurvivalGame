using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : BaseTurret
{
    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        UpdateTurretTarget();

        LockOnTarget();

        if (fireTimer >= fireRate && target != null)
        {
            CheckForEnemy();
        }
        if (fireTimer >= fireRate * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
}
