/*
 * Script para Habilidad de Curar
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class CharacterHeal : MonoBehaviour
    {
        [SerializeField] private float amountHeal = 10.0f;
        [SerializeField] private float cooldown = 2.5f;
        private float cooldownTimer = 0.0f;

        private PlayerHealth vida;
        private HealthBar healthBar;

        private void Start()
        {
            if (gameObject.GetComponent<PlayerHealth>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerHealth");
            if (gameObject.GetComponent<PlayerHealth>() != null) vida = gameObject.GetComponent<PlayerHealth>();
            if (gameObject.GetComponentInChildren<HealthBar>() == null) Debug.LogError(gameObject.name + " no tiene componente HealthBar");
            if (gameObject.GetComponentInChildren<HealthBar>() != null) healthBar = gameObject.GetComponentInChildren<HealthBar>();
            
        }

        private void Update()
        {
            if (vida != null)
            {
                if (Input.GetKeyDown(KeyCode.C) && (Time.time > cooldownTimer) && (vida.currentHealth < vida.maxHealth))
                {
                    DoHeal(amountHeal);
                }
            }
            
        }

        private void DoHeal(float amount)
        {
            vida.currentHealth += amount;

            if (vida.currentHealth > vida.maxHealth)
            {
                vida.currentHealth = vida.maxHealth;
            }

            // TODO: Efecto Particulas
            // TODO: UI
            // TODO: Actualizar Barra Vida

            cooldownTimer = Time.time + cooldown;
            if (healthBar != null) healthBar.SetHealth(vida.currentHealth);
            Debug.Log("im healing");
        }
    }
}
