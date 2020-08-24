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

        //public Health_Bar_Script healthBar;
        private void Start()
        {
            //CAMBIE EL COMPONENTE A PLAYERHEALTH PORQUE ES EL QUE ESTABA USANDO. !!
            
            if (gameObject.GetComponent<PlayerHealth>() == null) Debug.LogError(gameObject.name + "no tiene componente Health");
            if (gameObject.GetComponent<PlayerHealth>() != null) vida = gameObject.GetComponent<PlayerHealth>();
            
        }

        private void Update()
        {
            if (vida != null)
            {
                if (Input.GetKeyDown(KeyCode.C) && Time.time > cooldownTimer)
                {
                    DoHeal(amountHeal);
                    cooldownTimer = Time.time + cooldown;
                    //healthBar.SetHealth(vida.currentHealth);
                    Debug.Log("im healing");
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
