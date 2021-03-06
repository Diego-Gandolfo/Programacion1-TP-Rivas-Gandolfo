﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 10f;
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

            SoundManager.PlaySound("PlayerTakeDamage");

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
}
