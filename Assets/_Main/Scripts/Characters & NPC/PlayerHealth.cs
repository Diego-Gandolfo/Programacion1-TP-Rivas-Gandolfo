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

        public GameObject blood;

        public HealthBar healthBar;

        public Action OnDie;

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
                healthBar.animator.SetTrigger("BrokenHeart");
            }
            else if (currentHealth >= 5)
            {
                healthBar.brokenHeartIcon.gameObject.SetActive(false);
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
            OnDie.Invoke();
            //Destroy(gameObject);
            //healthBar.gameObject.SetActive(false);
        }
    }
}
