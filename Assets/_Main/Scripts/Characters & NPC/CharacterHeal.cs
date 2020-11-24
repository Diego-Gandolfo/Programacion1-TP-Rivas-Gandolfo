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
        [SerializeField] private float amountHeal = 10.0f;
        [SerializeField] private float cooldown = 2.5f;
        private float cooldownTimer = 0.0f;
        private bool canCount = false;
        private bool canHeal = true;

        [SerializeField] private Animator animatorEffects = null;
        [SerializeField] private ParticleSystem healEffect = null;
        private PlayerHealth vida;
        [SerializeField] private HealthBar healthBar; // Ahora la HealthBar hay que asignarla

        [SerializeField] private Image imageUI = null;

        private void Start()
        {
            if (gameObject.GetComponent<PlayerHealth>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerHealth");
            if (gameObject.GetComponent<PlayerHealth>() != null) vida = gameObject.GetComponent<PlayerHealth>();

            cooldownTimer = cooldown;
        }

        private void Update()
        {
            if (!CutsceneTrigger.isCutsceneOn)
            {
                if (Input.GetKeyDown(KeyCode.C) && (canHeal) && (vida.currentHealth < vida.maxHealth))
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
