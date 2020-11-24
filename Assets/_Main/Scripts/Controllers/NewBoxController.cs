using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class NewBoxController : MonoBehaviour
    {
        [SerializeField] 
        private Transform player = null;

        [SerializeField] 
        private float maxHealth = 0.5f;

        [SerializeField] 
        private float currentHealth = 0f;

        [SerializeField] 
        private Animator animator = null;

        private BoxCollider2D boxCollider = null;

        [SerializeField] 
        private bool canInstantiate = false;

        [SerializeField] 
        private GameObject fragmentoDeMemoria = null;

        [SerializeField] 
        private GameObject instantiator = null; 

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

                if (canInstantiate)
                {
                    GameObject instance = Instantiate(fragmentoDeMemoria, instantiator.transform.position, Quaternion.identity);
                    ShootingAI shootingAI = instance.GetComponent<ShootingAI>();
                    if (shootingAI != null) shootingAI.player = player;
                }
            }
        }
    }
}
