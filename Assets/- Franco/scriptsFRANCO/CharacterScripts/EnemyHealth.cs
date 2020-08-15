using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    public float currentHeatlh;
    void Start()
    {
        currentHeatlh = maxHealth;
    }

    public void TakePlayerDamage(float damage)
    {
        currentHeatlh -= damage;
        if (currentHeatlh <= 0) Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
