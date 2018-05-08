using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
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

    public LineRenderer gunLR;

    [HideInInspector]
    public Ray shootRay;

    [HideInInspector]
    RaycastHit shootHit;

    int shootableMask;

    //ParticleSystem

    //Light

    //AudioSource

    [SerializeField]
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

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && fireTimer >= fireRate && noAmmo == false)
        {
            Fire();
        }

        if (fireTimer >= fireRate * effectDisplayTime)
        {
            DisableEffects();
        }

        Reload();

    }

    public void Fire()
    {
        fireTimer = 0;

        curClipSize--;

        gunLR.enabled = true;
        gunLR.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

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

    void DisableEffects()
    {
        gunLR.enabled = false;
        //Particles
        //Audio
        //Lights
    }

}
