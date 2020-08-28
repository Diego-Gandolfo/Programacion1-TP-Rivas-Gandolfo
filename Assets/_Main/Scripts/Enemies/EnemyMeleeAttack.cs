using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        private int damage = 2;
        public float attackRate = 2f;
        private float nextAttack = 0f;

        public float speed = 5f;
        
        public Animator animator;

        public Transform player;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null && Time.time >= nextAttack)
            {
                animator.SetTrigger("Attack");
            
                player.TakeDamage(damage);
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }
}

