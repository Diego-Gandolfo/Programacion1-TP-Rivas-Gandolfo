using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 10f;
        public float currentHealth;

//        public GameObject player; // Esta variable no es necesaria
        public GameObject blood;

        public HealthBar healthBar;

        
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            if (currentHealth <= 5)
            {
                healthBar.brokenHeartIcon.gameObject.SetActive(true);
                
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            
            //SOUND
            SoundManager.PlaySound("PlayerTakeDamage");
            //HEALTH BAR
            healthBar.SetHealth(currentHealth);
            //BLOOD VFX
            Instantiate(blood, transform.position, Quaternion.identity);


            if (currentHealth <= 0) Die();
        }

        void Die()
        {
//            Destroy(player);
            Destroy(gameObject); // En lugar de usar la una variable que referencie al Player, directamente lo destruimos
            healthBar.gameObject.SetActive(false);
        }
    }
}
