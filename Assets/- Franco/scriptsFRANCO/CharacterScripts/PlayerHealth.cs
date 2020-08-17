using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    public float currentHealth;

    public GameObject player;
    public GameObject blood;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Instantiate(blood, transform.position, Quaternion.identity);
        if (currentHealth <= 0) Die();
    }
    void Die()
    {
        Destroy(player);
    }
}
