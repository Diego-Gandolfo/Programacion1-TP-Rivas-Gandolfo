using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    public float currentHeatlh;

    public Health_Bar_Script enemyHealthBar;
    void Start()
    {
        currentHeatlh = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    public void TakePlayerDamage(float damage)
    {
        currentHeatlh -= damage;

        enemyHealthBar.SetHealth(currentHeatlh);

        if (currentHeatlh <= 0) Die();
    }
    void Die()
    {
        Destroy(gameObject);
        enemyHealthBar.gameObject.SetActive(false);
    }
}
