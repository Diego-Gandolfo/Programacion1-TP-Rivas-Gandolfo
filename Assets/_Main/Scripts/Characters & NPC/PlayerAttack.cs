﻿using OnceUponAMemory.Franco;
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
        private bool canUseGrenade = true;

        private int maxGrenades = 5;
        [SerializeField] private int currentGrenades = 0;
        
        [Header("Visual Feedback")]
        [SerializeField] private Animator animatorSword = null;

        [SerializeField] private Image imageUI = null;

        public GameObject swordTrail;

        [SerializeField] private GameObject grenadePrefab;
        [SerializeField] private GameObject grenadePoint;
        private float grenadeSpeedForce = 10.0f;
        
        private void Start()
        {
            cooldownTimer = attackCooldown;
            swordTrail.gameObject.SetActive(false);

            currentGrenades = maxGrenades;
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
            if(Input.GetKeyDown(KeyCode.Space) && canUseGrenade)
            {
                ShootGrenade();

                currentGrenades -= 1;

                if(currentGrenades <= 0)
                {
                    canUseGrenade = false;
                    Debug.Log("No more grenades!");
                }
            }

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
                else if (target.GetComponent<NewBoxController>() != null)
                {
                    target.GetComponent<NewBoxController>().TakePlayerDamage(damage);
                }
            }

            SoundManager.PlaySound("AttackSound");
            animatorSword.SetTrigger("doAttack");
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPosition != null) Gizmos.DrawWireSphere(attackPosition.position, attackRange); // Esto es para dibujar donde está el Overlap
        }

        void ShootGrenade()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - transform.position;

            GameObject grenade = Instantiate(grenadePrefab, grenadePoint.transform.position, grenadePoint.transform.rotation);
            Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * grenadeSpeedForce, ForceMode2D.Impulse);
        }
    }
}
