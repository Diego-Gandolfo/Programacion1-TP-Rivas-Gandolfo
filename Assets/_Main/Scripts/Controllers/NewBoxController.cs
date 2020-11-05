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

        private BoxCollider2D boxCollider = null;

        [SerializeField] private bool canInstantiate = false;

        [SerializeField] private GameObject fragmentoDeMemoria;
        [SerializeField] private GameObject instantiator; 

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakePlayerDamage(float damage)
        {
            currentHealth -= damage;
            SoundManager.PlaySound("CrateDamage");

            animator.SetTrigger("Damaged");
            
            if (currentHealth <= 0)
            {
                animator.SetTrigger("Destroyed");
                SoundManager.PlaySound("BreakCrate");

                if (boxCollider != null) boxCollider.enabled = false;

                if (canInstantiate) Instantiate(fragmentoDeMemoria, instantiator.transform.position, Quaternion.identity);
            }
        }
    }
}
