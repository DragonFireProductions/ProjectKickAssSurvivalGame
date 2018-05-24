using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public Stat health;

    EnemyTargetManager enemyTM;

    void Start ()
    {
        
    }
	
	void Update ()
    {
        CheckForDamage();
	}

    void Awake()
    {
        enemyTM = FindObjectOfType<EnemyTargetManager>();
        enemyTM.AddTarget(transform);
        health.SetValues();
    }

    public virtual void CheckForDamage()
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

    public virtual void Die()
    {
        if (enemyTM != null)
        {
            enemyTM.RemoveTarget(transform);
        }

        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (enemyTM != null)
        {
            enemyTM.RemoveTarget(transform);
        }
    }
}
