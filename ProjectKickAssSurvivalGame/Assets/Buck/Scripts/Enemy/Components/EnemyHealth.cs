using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth;

    //[HideInInspector]
    public float curHealth;

    [SerializeField]
    Image healthBar;

    public GameObject coin;

    public int minCoins;

    public int maxCoins;

    // Use this for initialization
    void Start ()
    {
        curHealth = maxHealth;
	}

    //This can be called from other scripts that would apply
    //Damage to the enemy
    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        curHealth -= amount;

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

    //When the enemies health reaches 0
    //Drop coins, and destroy the object
    public void Die()
    {
        //Randomly reward the player a number of coins from the 
        //Min and Max ints
        int reward = Random.Range(minCoins, maxCoins);

        for (int i = 0; i < reward; i++)
        {
            //Make them coins
            Instantiate(coin, transform.position, transform.rotation);
        }
        //Destroy that baddie
        Destroy(gameObject);
    }
}
