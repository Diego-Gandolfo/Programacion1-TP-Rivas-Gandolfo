using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private float currentHeatlh;

    public Health_Bar_Script healthBar;
    
    void Start()
    {
        currentHeatlh = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakePlayerDamage(float damage)
    {
        currentHeatlh -= damage;

        healthBar.SetHealth(currentHeatlh);


        if (currentHeatlh <= 0) Die();
    }
    void Die()
    {
        Destroy(gameObject);
        healthBar.gameObject.SetActive(false);
    }
}
