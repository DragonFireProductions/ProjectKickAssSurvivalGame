using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTurret : MonoBehaviour
{
    [Header("TurretSettings")]

    public float fireRate;

    public float range;

    public float damagePerShot;

    public float rotateSpeed;

    public float maxHealth;

    public float curHealth;

    public Image healthBar;

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

    public GameObject turretSpotLight;

    public float effectsDisplayTime;

    SphereCollider turretRange;

    public string enemytag = "Enemy";

    Ray shootRay;

    RaycastHit shootHit;

    int shootableMask;

    int floorMask;

    float camRayLength = 100f;

    //[SerializeField]
    DayNightCycle dayRef;

    //[SerializeField]
    GameObject sun;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        floorMask = LayerMask.GetMask("Floor");
        sun = GameObject.FindGameObjectWithTag("Sun");
        dayRef = sun.GetComponent<DayNightCycle>();
        turretLR = GetComponentInChildren<LineRenderer>();
        turretLight = GetComponentInChildren<Light>();
        Light turretSpotLight = gameObject.GetComponent<Light>();

        curHealth = maxHealth;
    }

    public void CheckTime()
    {
        if (dayRef.GetMeridiem() == DayNightCycle.Meridiem.AM)
        {
             turretSpotLight.SetActive(false);

            if (dayRef.GetHour() <= 6f)
            {
                turretSpotLight.SetActive(true);
            }
        }
        else
        {
            if (dayRef.GetHour() >= 6f)
            {
                turretSpotLight.SetActive(true);
            }
        }
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

    public void CheckForEnemy()
    {
        shootRay.origin = firePoint.position;
        shootRay.direction = firePoint.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask) && shootHit.collider.tag == enemytag)
        {
            Fire();
        }
        else
        {
            Debug.DrawRay(firePoint.position, firePoint.forward * 1000f, Color.red);
        }
    }

    public void Fire()
    {
        fireTimer = 0;

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

    //This can be called from other scripts that would apply
    //Damage to the turret
    public void TakeDamage(float amount /*, Vector3 hitPoint*/)
    {
        curHealth -= amount;

        //if (curHealth == maxHealth)
        //{
        //    healthBar.enabled = false;
        //}
        //else
        //{
        //    healthBar.enabled = true;
        //}

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

    public void Die()
    {
        //PLAY BREAK ANIMATION DESTROY AFTER SO 
        //MANY SECONDS
        Destroy(gameObject);
    }

    public void DisableEffects()
    {
        turretLR.enabled = false;
        turretLight.enabled = false;
    }
}
