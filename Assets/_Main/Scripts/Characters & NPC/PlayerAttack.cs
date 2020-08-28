using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        private bool canAttack = true;
        private bool canCount = false;

        [SerializeField] private Animator animatorSword = null;

        [SerializeField] private Image imageUI = null;

        private void Start()
        {
            cooldownTimer = attackCooldown;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && (canAttack))
            {
                canAttack = false;
                canCount = true;
                Attack();
            }

            if ((cooldownTimer <= 0) && (canCount))
            {
                cooldownTimer = attackCooldown;
                canAttack = true;
                canCount = false;
                imageUI.fillAmount = 1;
            }
            else if ((cooldownTimer > 0) && (canCount))
            {
                cooldownTimer -= Time.deltaTime;
                imageUI.fillAmount = 1 - (cooldownTimer / attackCooldown);
            }
        }
        private void Attack()
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
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPosition != null) Gizmos.DrawWireSphere(attackPosition.position, attackRange); // Esto es para dibujar donde está el Overlap
        }
    }
}
