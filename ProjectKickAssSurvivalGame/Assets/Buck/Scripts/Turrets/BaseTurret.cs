using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : MonoBehaviour
{
    [Header("TurretSettings")]

    public float fireRate;

    public float range;

    public float damagePerShot;

    public float effectsDisplayTime;

    public float rotateSpeed;

    [HideInInspector]
    public float fireTimer;

    [Header("UnitySettings")]

    public Transform turretHead;

    public Transform partToRotate;

    public Transform firePoint;

    [HideInInspector]
    public Transform target;

    public LineRenderer turretLR;

    public Light turretLight;

    SphereCollider turretRange;

    public string enemytag = "Enemy";

    Ray shootRay;

    RaycastHit shootHit;

    int shootableMask;

    int floorMask;

    float camRayLength = 100f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        floorMask = LayerMask.GetMask("Floor");
        turretLR = GetComponentInChildren<LineRenderer>();
        turretLight = GetComponentInChildren<Light>();
        turretRange = GetComponent<SphereCollider>();

        turretRange.radius = range;
    }

    public void UpdateTurretTarget()
    {
        //Find the tag named enemy tag of all the objects within the
        //Array of GameObjects
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void LockOnTarget()
    {

        if (target != null)
        {
            //Turn from current transform, to the targets transform
            Vector3 dir = target.position - transform.position;

            Quaternion lookRotation = Quaternion.LookRotation(dir);

            //This is so that if an enemy exits the turrets range and another comes in
            //It doesn't snap right to the next target
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;

            //The pivot point turns on the y rotation only 
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        else
        {
            return;
        }
    }

    public void Fire()
    {
        fireTimer = 0;

        firePoint.LookAt(target);
        turretHead.LookAt(target);

        turretLR.enabled = true;
        turretLight.enabled = true;

        turretLR.SetPosition(0, firePoint.position);

        shootRay.origin = firePoint.position;
        shootRay.direction = firePoint.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            BaseEnemy enemyHealth = shootHit.collider.GetComponent<BaseEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            turretLR.SetPosition(1, shootHit.point);
        }
        else
        {
            turretLR.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void DisableEffects()
    {
        turretLR.enabled = false;
        turretLight.enabled = false;
    }
}
