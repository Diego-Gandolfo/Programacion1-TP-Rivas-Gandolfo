using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    public float currentHealth;

    public GameObject player;
    public GameObject blood;

    public Health_Bar_Script healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        Instantiate(blood, transform.position, Quaternion.identity);

        if (currentHealth <= 0) Die();
    }
    void Die()
    {
        Destroy(player);
        healthBar.gameObject.SetActive(false);
    }
}
