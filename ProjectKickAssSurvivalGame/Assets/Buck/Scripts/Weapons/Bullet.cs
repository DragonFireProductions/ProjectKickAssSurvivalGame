using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public int damage;

    void Update()
    {
        BulletMovement();
    }

    void BulletMovement()
    {
        transform.Translate(0.0f, 0.0f, bulletSpeed * Time.deltaTime, Space.Self);
    }

    //Cleaning up missed bullets
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
