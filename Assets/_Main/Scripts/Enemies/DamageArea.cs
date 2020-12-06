using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class DamageArea : MonoBehaviour
    {
        [SerializeField] private int damage = 2;
        public float damageRate = 2f;
        private float nextDamage = 0f;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            PlayerHealth player = other.transform.GetComponent<PlayerHealth>();

            if (player != null && Time.time >= nextDamage)
            {
                player.TakeDamage(damage);
                //animator.SetTrigger("doActivate");
                nextDamage = Time.time + 1f / damageRate;
            }
        }
    }
}
