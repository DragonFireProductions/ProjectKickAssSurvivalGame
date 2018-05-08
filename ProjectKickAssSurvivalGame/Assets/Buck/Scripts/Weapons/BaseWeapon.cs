using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("WeaponStats")]
    public int maxClipSize;

    [HideInInspector]
    public int curClipSize;

    public float fireRate;

    public float range;

    public float damagePerShot;

    [HideInInspector]
    public float fireTimer;

    [Header("UnitySettings")]

    public Transform firePoint;

    [HideInInspector]
    public Ray shootRay;

    [HideInInspector]
    RaycastHit shootHit;

    int shootableMask;

    public LineRenderer gunLR;

    //ParticleSystem

    //Light

    //AudioSource

    float effectDisplayTime;

    bool noAmmo;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLR = GetComponent<LineRenderer>();
    }

    void Start()
    {
        noAmmo = false;

        curClipSize = maxClipSize;
    }

    public void Fire()
    {
        if (Input.GetButton("Fire1") && fireTimer >= fireRate && noAmmo == false)
        {

            curClipSize--;

            gunLR.enabled = true;
            gunLR.SetPosition(0, firePoint.position);

            shootRay.origin = firePoint.position;
            shootRay.direction = firePoint.forward;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
                gunLR.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLR.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }

            if (curClipSize == 0)
            {
                noAmmo = true;
                return;
            }
        }

        if (fireTimer >= fireRate * effectDisplayTime)
        {
            DisableEffects();
        }
    }

    public void Reload()
    {
        if (curClipSize <= maxClipSize)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                curClipSize = maxClipSize;
                noAmmo = false;
                return;
            }

            if (curClipSize <= 0)
            {
                curClipSize = 0;
                return;
            }
        }
    }

    public void DisableEffects()
    {
        gunLR.enabled = false;
    }

}
