using UnityEngine;
using UnityEngine.UI;

public class TurretHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

    [HideInInspector]
    public float curHealth;

    [SerializeField]
    Image healthBar;

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
