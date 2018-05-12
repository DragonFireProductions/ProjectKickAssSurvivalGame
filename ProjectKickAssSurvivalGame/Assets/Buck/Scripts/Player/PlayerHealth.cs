using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;

    [HideInInspector]
    public float curHealth;

    public Image healthBar;


    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;

        healthBar.fillAmount = curHealth / maxHealth;

        if (curHealth <= 0)
        {
            curHealth = 0;

            Die();
        }
    }

    void Die()
    {
        //PLAY DIE ANIMATION
    }
}
