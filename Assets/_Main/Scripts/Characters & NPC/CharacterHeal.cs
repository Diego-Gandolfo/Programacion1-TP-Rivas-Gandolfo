﻿/*
 * Script para Habilidad de Curar
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class CharacterHeal : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float amountHeal = 10.0f;
        [SerializeField] private float staminaCost = 1.0f;
        private PlayerStamina stamina;
        [SerializeField] private HealthBar healthBar; // Ahora la HealthBar hay que asignarla
        private PlayerHealth vida;

        [Header("Cooldown")]
        [SerializeField] private float cooldown = 2.5f;
        [SerializeField] private Image imageUI = null;
        private float cooldownTimer = 0.0f;
        private bool canCount = false;
        private bool canHeal = true;

        [Header("Effect")]
        [SerializeField] private ParticleSystem healEffect = null;

        private void Awake()
        {
            if (gameObject.GetComponent<PlayerHealth>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerHealth");
            if (gameObject.GetComponent<PlayerHealth>() != null) vida = gameObject.GetComponent<PlayerHealth>();
            if (gameObject.GetComponent<PlayerStamina>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerStamina");
            if (gameObject.GetComponent<PlayerStamina>() != null) stamina = gameObject.GetComponent<PlayerStamina>();
        }

        private void Start()
        {
            cooldownTimer = cooldown;
        }

        private void Update()
        {
            if (!CutsceneTrigger.isCutsceneOn)
            {
                if (Input.GetKeyDown(KeyCode.C) && (canHeal) && (vida.currentHealth < vida.maxHealth) && stamina.ReduceStamina(staminaCost))
                {
                    canHeal = false;
                    canCount = true;
                    DoHeal(amountHeal);
                }

                if ((cooldownTimer <= 0) && (canCount))
                {
                    cooldownTimer = cooldown;
                    canHeal = true;
                    canCount = false;
                }
                else if ((cooldownTimer > 0) && (canCount))
                {
                    cooldownTimer -= Time.deltaTime;
                    imageUI.fillAmount = 1 - (cooldownTimer / cooldown);
                }
            }
        }

        private void DoHeal(float amount)
        {
            vida.currentHealth += amount;

            if (vida.currentHealth >= vida.maxHealth)
            {
                vida.currentHealth = vida.maxHealth;
            }

            healEffect.Play();
            imageUI.fillAmount = 1;
            SoundManager.PlaySound("PickUpItemHeal");

            if (healthBar != null) healthBar.SetHealth(vida.currentHealth / vida.maxHealth); // Le pasa un procentaje
        }
    }
}
