using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("WeaponStats")]
    public int maxClipSize;

    [HideInInspector]
    public int curClipSize;

    //fireRate

    //fireTimer

    [Header("UnitySettings")]

    public GameObject bulletPrefab;

    public Transform firePoint;

    bool noAmmo;

    void Start()
    {
        noAmmo = false;

        curClipSize = maxClipSize;
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0) && noAmmo == false)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            curClipSize--;

            if (curClipSize == 0)
            {
                noAmmo = true;
                return;
            }
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

}
