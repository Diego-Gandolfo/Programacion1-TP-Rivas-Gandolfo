using System;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class Health_PowerUp : MonoBehaviour
    {
        public float healthBonus = 2;
        PlayerHealth playerHealth;

        private void Start()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                Destroy(gameObject);

                playerHealth.currentHealth += healthBonus;
            }
        }
    }
}
