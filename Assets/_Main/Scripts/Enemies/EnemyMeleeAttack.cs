using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [Header("Attack Settings")]
        [SerializeField] private float damage = 2f;
        [SerializeField] private float attackRate = 2f;
        private float nextAttack = 0f;

        [Header("Animator")]
        [SerializeField] private Animator animator;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null && Time.time >= nextAttack) Attack(player);
        }

        private void Attack(PlayerHealth player)
        {
            animator.SetTrigger("Attack");
            player.TakeDamage(damage);
            nextAttack = Time.time + 1f / attackRate;
        }
    }
}
