﻿/*
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
        [SerializeField] private float speed = 50f; // Configuramos cuanto se mueve al usar el Dash (con MovePosition)
        //[SerializeField] private float impulse = 50f; // Configuramos cuanto se mueve al usar el Dash (con AddForce)
        [SerializeField] private float duration = 0.25f; // Configuramos cuanto se mueve al usar el Dash
        [SerializeField] private float cooldown = 2; // Configuramos el Cooldown del Dash
        private Vector3 mousePosition = Vector3.zero; // Almacenaremos la posicion del Mouse al hacer click derecho
        private float durationTimer = 0.0f; // Contador de tiempo para la Duracion
        private float cooldownTimer = 0.0f; // Contador de tiempo para el Enfriamiento
        private bool canDash = true; // Indicaremos si puede hacer el Dash
        private bool startCooldown = false; // Indicamos si debe estar haciendo el Cooldown

        [SerializeField] private Image imageUI = null;

        public GameObject trail;
        
        public ParticleSystem Dust_Dash;

        private Rigidbody2D rb2D = null; // Para almacenar nuestro Rigidbody2D
        private Camera mainCamera = null;

        [SerializeField] private float staminaCost = 1.0f;
        private PlayerStamina stamina;

        // Para testeo
        //private bool doOnce = false;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            trail.gameObject.SetActive(false);
            durationTimer = 0; // Inicializamos el contador de Duracion
            cooldownTimer = cooldown; // Inicializamos el cooldownTimer con la duracion del Cooldown
            mainCamera = Camera.main;
            if (gameObject.GetComponent<PlayerStamina>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerStamina");
            if (gameObject.GetComponent<PlayerStamina>() != null) stamina = gameObject.GetComponent<PlayerStamina>();
        }

        private void Update()
        {
            // Input
            if (Input.GetButtonDown("Fire2") && canDash && stamina.ReduceStamina(staminaCost))
            {
                if (!CutsceneTrigger.isCutsceneOn)
                {
                    canDash = false; // Indicamos que no puede hacer Dash
                    startCooldown = true; // Indicamos que puede empezar el Cooldown
                    mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse
                    durationTimer = duration; // Inicializamos el contador de Duracion

                    SoundManager.PlaySound("Dash");

                    //CinemachineShake.Instance.ShakeCam(8f, .3f);


                    Dust_Dash.Play();

                    trail.gameObject.SetActive(true); // Activamos el Trail

                    /*
                    // Para testeo
                    doOnce = true;
                    */
                }

            }

            // Trail
            if (durationTimer > 0) // Verificamos si ya termino de contar la duración del Dahs
            {
                durationTimer -= Time.deltaTime; // Vamos llevando la cuenta regresiva
            }
            else
            {
                trail.gameObject.SetActive(false); // Desactivamos el Trail

            }

            // UI Icono Cooldown
            if ((cooldownTimer <= 0) && startCooldown) // Verificamos si termino el Cooldown y debe estar haciendo el Cooldown
            {
                startCooldown = false; // Que termino con el Cooldown
                cooldownTimer = cooldown; // Reincializamos el cooldownTimer para la próxima vez que se use
                canDash = true; // Le decimos que puede hacer Dash
                imageUI.fillAmount = 1; // Completamos al 100% el fillAmount de la Imagen del Cooldown
            }
            else if ((cooldownTimer > 0) && startCooldown) // Si no termino el Cooldown y debe estar haciendo el Cooldown
            {
                cooldownTimer -= Time.deltaTime; // Reducimos el cooldownTimer
                imageUI.fillAmount = 1 - (cooldownTimer / cooldown); // Vamos llenando el fillAmount de la Imagen del Cooldown
            }
        }

        private void FixedUpdate()
        {
            // Dash
            if (durationTimer > 0) // Verificamos si ya termino de contar la duración del Dahs
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.fixedDeltaTime); // Calculamos el siguiente punto
                rb2D.MovePosition(newPosition); // Nos movemos al punto indicado
                
                /*
                Vector2 direction = mousePosition - transform.position;
                direction.Normalize();
                rb2D.AddForce(direction * impulse, ForceMode2D.Impulse);
                */

                /*
                // Para testeo
                if (doOnce)
                {
                    doOnce = false;
                    print("-------------------------------------");
                    //print("rb2D Object: " + rb2D.gameObject.name);
                }
                //print("Duration Timer: " + durationTimer);
                //print("Mouse Position: " + mousePosition);
                //print("Transform Position: " + transform.position);
                //print("Direction: " + direction);
                //print("Impulso: " + impulse);
                //print("Direction * impulse: " + direction * impulse);
                //print("rb2D Velocity: " + rb2D.velocity);
                //print("Time.fixedDeltaTime: " + Time.fixedDeltaTime);
                //print("Time.timeScale: " + Time.timeScale);
                //print("Physics2D.gravity: " + Physics2D.gravity);
                */
            }
        }
    }
}
