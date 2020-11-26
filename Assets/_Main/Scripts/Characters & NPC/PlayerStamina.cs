using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class PlayerStamina : MonoBehaviour
    {
        public float maxStamina = 10f;
        public float currentStamina;

        public HealthBar healthBar; // La Esfera de Stamina

        void Start()
        {
            currentStamina = maxStamina;
            healthBar.SetMaxHealth(maxStamina);
        }

        private void Update()
        {
            if (healthBar.brokenHeartIcon != null) // Esto lo dejo por si lo usamos para la animacion de cuando le queda poca Stamina
            {
                if (currentStamina <= 5)
                {
                    healthBar.brokenHeartIcon.gameObject.SetActive(true);
                    healthBar.animator.SetTrigger("BrokenHeart");
                }
                else if (currentStamina >= 5)
                {
                    healthBar.brokenHeartIcon.gameObject.SetActive(false);
                }
            }
        }

        public bool ReduceStamina(float amount)
        {
            if ((currentStamina - amount) >= 0)
            {
                currentStamina -= amount;
                
                //HEALTH BAR
                //healthBar.SetHealth(currentHealth);
                healthBar.SetHealth(currentStamina / maxStamina); // Ahora le pasa un porcentaje

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
