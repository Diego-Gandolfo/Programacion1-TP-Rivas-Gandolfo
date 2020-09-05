using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Range and position")]
        public Transform attackPosition;
        [SerializeField] private float attackRange = 1.0f;
        
        [Header("Attack Parameters")]
        public LayerMask targetsLayerMask;
        [SerializeField] private float damage = 1.0f;
        [SerializeField] private float attackCooldown = 1.0f;
        [SerializeField] private float cooldownTimer = 0.0f;
        
        //BOOLS
        private bool canAttack = true;
        private bool canCount = false;
        
        [Header("Visual Feedback")]
        [SerializeField] private Animator animatorSword = null;

        [SerializeField] private Image imageUI = null;

        public GameObject swordTrail;

        private void Start()
        {
            cooldownTimer = attackCooldown;
            swordTrail.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && (canAttack))
            {
                canAttack = false;
                canCount = true;
                swordTrail.gameObject.SetActive(true); // Movi la activación del Trail acá, para aprovechar este IF
                Attack();
            }
/*
            if (canAttack != true)
            {
                swordTrail.gameObject.SetActive(true);
            }
            else
            {
                swordTrail.gameObject.SetActive(false);
            }
*/            
            if ((cooldownTimer <= 0) && (canCount))
            {
                cooldownTimer = attackCooldown;
                canAttack = true;
                canCount = false;
                imageUI.fillAmount = 1;
                swordTrail.gameObject.SetActive(false); // Movi la desactivación del Trail acá, para aprovechar este IF
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

                    //HitCounter.hitCount += 1;

                    CinemachineShake.Instance.ShakeCam(5f, .1f);
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
