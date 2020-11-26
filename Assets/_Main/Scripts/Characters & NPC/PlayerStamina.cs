using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] private float maxStamina = 10f;
        [SerializeField] private float currentStamina;

        [SerializeField] private float recoverPoints = 0f;
        [SerializeField] private float recoverTime = 0f;
        private float timer = 0f;

        [SerializeField] private HealthBar healthBar; // La Esfera de Stamina

        void Start()
        {
            currentStamina = maxStamina;
            healthBar.SetMaxHealth(maxStamina);
        }

        private void Update()
        {
            if (timer >= recoverTime)
            {
                if (currentStamina < maxStamina)
                {
                    currentStamina += recoverPoints;
                    ActualizeStaminaBar();
                }

                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }

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

                ActualizeStaminaBar();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void ActualizeStaminaBar()
        {
            //HEALTH BAR
            //healthBar.SetHealth(currentHealth);
            healthBar.SetHealth(currentStamina / maxStamina); // Ahora le pasa un porcentaje
        }
    }
}
