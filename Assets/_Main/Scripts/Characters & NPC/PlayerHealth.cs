﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private GameObject heartbeatSound;

        [SerializeField]
        private Animator HUDanimator;

        public float maxHealth = 10f;
        public float currentHealth;

        public GameObject blood;

        public HealthBar healthBar;

        private GameManager gameManager = null;

        public Action OnDie;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.SetPlayerHealth(this);
        }

        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            if (heartbeatSound != null) heartbeatSound.SetActive(false);
        }

        private void Update()
        {
            if (healthBar.brokenHeartIcon == null)
            {
                if (currentHealth <= 5)
                {
                    if (HUDanimator != null) HUDanimator.SetBool("LowHealth", true);
                    if (heartbeatSound != null) heartbeatSound.SetActive(true);
                }
                if (currentHealth >= 5)
                {
                    if (HUDanimator != null) HUDanimator.SetBool("LowHealth", false);
                    if (heartbeatSound != null) heartbeatSound.SetActive(false);
                }
            }

            if (healthBar.brokenHeartIcon != null)
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
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            
            //SOUND
            SoundManager.PlaySound("PlayerTakeDamage");
            //HEALTH BAR
            //healthBar.SetHealth(currentHealth);
            healthBar.SetHealth(currentHealth / maxHealth); // Ahora le pasa un porcentaje
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
