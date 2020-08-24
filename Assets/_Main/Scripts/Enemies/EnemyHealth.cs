using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float currentHeatlh;

        public Health_Bar_Script healthBar;

        public Animator animator;

        void Start()
        {
            currentHeatlh = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakePlayerDamage(float damage)
        {
            currentHeatlh -= damage;

            animator.SetTrigger("TakeDamage");

            healthBar.SetHealth(currentHeatlh);

            if (currentHeatlh <= 0) Die();
        }

        void Die()
        {
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
        }
    }
}
