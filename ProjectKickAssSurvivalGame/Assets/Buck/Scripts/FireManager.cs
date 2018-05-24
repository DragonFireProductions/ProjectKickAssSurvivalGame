using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    Inventory inv;
    EnemyTargetManager enemyTM;

    public Stat health;

    public float burnTime;
    float burnTimer;

    private void Awake()
    {
        enemyTM = FindObjectOfType<EnemyTargetManager>();
        inv = FindObjectOfType<Inventory>();
        health.SetValues();
    }

    void Start ()
    {
        enemyTM.AddTarget(transform);
    }
	

	void Update ()
    {
        CheckForDamage();
        BurnOut();
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

    public void BurnOut()
    {
        burnTimer += Time.deltaTime;

        if (burnTimer >= burnTime)
        {
            health.CurValue -= 1;
            burnTimer = 0;
        }
    }

    void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player" && Input.GetKeyDown(KeyCode.E) && inv.wood_resource >= 1)
        {
            inv.wood_resource -= 1;
            health.CurValue += 1;
        }
    }
}
