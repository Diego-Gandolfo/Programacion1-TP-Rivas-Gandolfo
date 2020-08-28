using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class PlayerAttack : MonoBehaviour
    {
        public Transform attackPosition;
        [SerializeField] private float attackRange = 1.0f;

        public LayerMask targetsLayerMask;
        [SerializeField] private float damage = 1.0f;
        [SerializeField] private float attackCooldown = 1.0f;
        [SerializeField] private float cooldownTimer = 0.0f;

        [SerializeField] private Animator animatorSword = null;

        private void Update()
        {
            if (!Input.GetButtonDown("Fire1") || !(Time.time >= cooldownTimer)) return;
            PlayerIs();
        }
        private void PlayerIs()
        {
            Collider2D[] targetshit = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, targetsLayerMask);

            foreach (Collider2D target in targetshit)
            {
                if (target.GetComponent<EnemyHealth>() != null)
                {
                    target.GetComponent<EnemyHealth>().TakePlayerDamage(damage);
                    //Debug.Log("im being damaged");
                    SoundManager.PlaySound("EnemyHitRebuild");
                }
            }

            SoundManager.PlaySound("AttackSound");
            animatorSword.SetTrigger("doAttack");

            cooldownTimer = Time.time + attackCooldown;
        }
    }
}
