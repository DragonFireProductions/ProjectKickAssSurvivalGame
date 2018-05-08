using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    EnemyMeleeAttack meleeAttack;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerFire = GameObject.FindGameObjectWithTag("Fire").transform;

        LocateTarget();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateTarget();
        Navigation();
	}

    void UpdateTarget()
    {
        attackTimer += Time.deltaTime;

        float playerDistance = Vector3.Distance(player.transform.position, transform.position);

        float fireDistance = Vector3.Distance(playerFire.transform.position, transform.position);

        if (target != null)
        {
            if (playerDistance >= fireDistance)
            {
                target = playerFire;

                if (fireDistance <= 0.5f)
                {
                    //AttackFire();
                    attackTimer = 0f;
                    return;
                }
            }

            else if (playerDistance < fireDistance)
            {
                target = player;

                if (playerDistance <= 1f)
                {
                     //AttackPlayer();
                    attackTimer = 0f;
                    return;
                }
            }
        }
    }
}
