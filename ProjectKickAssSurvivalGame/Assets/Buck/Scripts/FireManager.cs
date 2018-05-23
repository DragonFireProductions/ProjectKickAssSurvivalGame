using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{

    EnemyTargetManager enemyTM;

    public Stat health;

    int shootableMask;
    int floorMask;

    private void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        floorMask = LayerMask.GetMask("Floor");
        enemyTM = FindObjectOfType<EnemyTargetManager>();
        health.SetValues();
    }

    void Start ()
    {
        enemyTM.AddTarget(transform);
    }
	

	void Update ()
    {
        CheckForDamage();
    }

    public void CheckForDamage()
    {
        if (health.CurValue == health.MaxValue)
        {
            health.bar.gameObject.SetActive(false);
        }
        else
        {
            health.bar.gameObject.SetActive(true);
        }
    }

    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        health.CurValue -= amount;

        if (health.CurValue <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (enemyTM != null)
        {
            enemyTM.RemoveTarget(transform);
        }

        Destroy(gameObject);
        
    }
}
