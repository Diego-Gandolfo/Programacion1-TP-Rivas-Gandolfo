using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class NewBoxController : MonoBehaviour
    {
        private float maxHealth = 3;
        [SerializeField] private float currentHealth;

        [SerializeField] private Animator animator;
    
        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakePlayerDamage(float damage)
        {
            currentHealth -= damage;
            
            animator.SetTrigger("Damaged");
            
            if (currentHealth <= 0)
                animator.SetTrigger("Destroyed");

        }
    }
}
