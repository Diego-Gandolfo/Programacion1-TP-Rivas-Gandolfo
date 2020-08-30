/*
 * Script para habilidad de Dash
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class CharacterDash : MonoBehaviour
    {
        [SerializeField] private float speed = 20; // Configuramos cuanto se mueve al usar el Dash
        [SerializeField] private float duration = 1; // Configuramos cuanto se mueve al usar el Dash
        [SerializeField] private float cooldown = 1; // Configuramos el Cooldown del Dash
        private Vector3 mousePosition = Vector3.zero; // Almacenaremos la posicion del Mouse al hacer click derecho
        private float durationTimer = 0.0f; // Contador de tiempo para la Duracion
        private float cooldownTimer = 0.0f; // Contador de tiempo para el Enfriamiento
        private bool canDash = true; // Indicaremos si puede hacer el Dash
        private bool canCount = false;

        [SerializeField] private Image imageUI = null;

        public GameObject trail;
        
        private void Start()
        {
            trail.gameObject.SetActive(false);
            durationTimer = duration; // Inicializamos el contador de Duracion
            cooldownTimer = cooldown;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire2") && canDash)
            {
                canDash = false; // Indicamos que no puede hacer Dash
                canCount = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse
                durationTimer = duration; // Inicializamos el contador de Duracion
                // TODO: Efecto de Particulas
                // TODO: Animacion

                SoundManager.PlaySound("Dash");
                
                CinemachineShake.Instance.ShakeCam(8f, .3f);
            }

           // TODO: UI?

            if (canDash != true)
            {
                trail.gameObject.SetActive(true);
            }
            else
            {
                trail.gameObject.SetActive(false);
            }

          
            if (durationTimer > 0) // Verificamos si ya termino de contar
            {
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime); ; // Nos movemos al punto indicado
                durationTimer -= Time.deltaTime; // Vamos llevando la cuenta regresiva
                
                
            }

            if ((cooldownTimer <= 0) && (canCount))
            {
                cooldownTimer = cooldown;
                canDash = true;
                canCount = false;
                imageUI.fillAmount = 1;
                
                
            }
            else if ((cooldownTimer > 0) && (canCount))
            {
                cooldownTimer -= Time.deltaTime;
                imageUI.fillAmount = 1 - (cooldownTimer / cooldown);
                
            }
        }
    }
}
