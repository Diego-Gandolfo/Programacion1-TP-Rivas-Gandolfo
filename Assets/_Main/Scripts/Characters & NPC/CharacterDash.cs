/*
 * Script para habilidad de Dash
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private bool doOnce = false; // Bandera que ayudara a no entre en parte del codigo innecesariamente

        private void Update()
        {
            if (Input.GetButtonDown("Fire2") && Time.time > cooldownTimer && canDash)
            {
                canDash = false; // Indicamos que no puede hacer Dash
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse
                durationTimer = duration; // Inicializamos el contador de Duracion
                doOnce = true; // Habilitamos la Bandera
                cooldownTimer = Time.time + cooldown; // Reseteamos el contador del Cooldown
                // TODO: Efecto de Particulas
                // TODO: Animacion
            }

            if (durationTimer > 0) // Verificamos si ya termino de contar
            {
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime); ; // Nos movemos al punto indicado
                durationTimer -= Time.deltaTime; // Vamos llevando la cuenta regresiva

            }
            else if (doOnce) // Al terminar
            {
                doOnce = false; // Ponemos la Bandera en FALSE para que no vuelva a entrar hasta la proxima vez que se realice el Dash
                canDash = true; // Le decimos que puede volver a hacer el Dash
            }
        }
    }
}
