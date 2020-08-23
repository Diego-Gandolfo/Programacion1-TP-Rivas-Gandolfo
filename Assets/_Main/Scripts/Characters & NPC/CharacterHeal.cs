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
        private Health vida;

        private void Start()
        {
            if (gameObject.GetComponent<Health>() == null) Debug.LogError(gameObject.name + "no tiene componente Health");
            if (gameObject.GetComponent<Health>() != null) vida = gameObject.GetComponent<Health>();
        }

        private void Update()
        {
            if (vida != null)
            {
                if (Input.GetKeyDown("space") && Time.time > cooldownTimer)
                {
                    DoHeal(amountHeal);
                    cooldownTimer = Time.time + cooldown;
                }
            }
        }

        private void DoHeal(float amount)
        {
            if (vida.currentHealth + amount <= vida.maxHealth)
            {
                vida.currentHealth += amount;
                // TODO: Efecto Particulas
                // TODO: UI
                // TODO: Actualizar Barra Vida
            }
        }
    }
}
