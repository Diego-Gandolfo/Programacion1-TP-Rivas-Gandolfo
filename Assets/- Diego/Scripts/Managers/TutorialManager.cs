/*
 * Script que se encargará de gestionar el Tutorial
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("Manager")]
        [SerializeField] private float timeToStart = 0f; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        private bool canStart = false; // Indicaremos cuando completo el Tutorial de Movimiento

        [Header("Movement")]
        [SerializeField] private GameObject movementObject = null; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        [SerializeField] private float movementTimeToHide = 0f; // Tiempo para ocultar el Objeto Movimiento
        private float movementTimeToHideTimer = Mathf.Infinity;
        private bool movementDone = false; // Indicaremos cuando completo el Tutorial de Movimiento

        [Header("Dash")]
        [SerializeField] private GameObject dashObject = null; // Almacenaremos el Objeto que contiene el Cartel de Dash
        [SerializeField] private float dashTimeToHide = 0f; // Tiempo para ocultar el Objeto Dash
        private float dashTimeToHideTimer = Mathf.Infinity;
        private bool dashDone = false; // Indicaremos cuando completo el Tutorial de Dash

        [Header("Heal")]
        [SerializeField] private GameObject healObject = null; // Almacenaremos el Objeto que contiene el Cartel de Heal
        [SerializeField] private float healTimeToHide = 0f; // Tiempo para ocultar el Objeto Heal
        private float healTimeToHideTimer = Mathf.Infinity;
        private bool healDone = false; // Indicaremos cuando completo el Tutorial de Heal

        [Header("Attack")]
        [SerializeField] private GameObject attackObject = null; // Almacenaremos el Objeto que contiene el Cartel de Attack
        [SerializeField] private float attackTimeToHide = 0f; // Tiempo para ocultar el Objeto Attack
        private float attackTimeToHideTimer = Mathf.Infinity;
        private bool attackDone = false; // Indicaremos cuando completo el Tutorial de Attack

        private void Start()
        {
            movementTimeToHideTimer = Mathf.Infinity;
            dashTimeToHideTimer = Mathf.Infinity;
            healTimeToHideTimer = Mathf.Infinity;
            attackTimeToHideTimer = Mathf.Infinity;
        }

        private void Update()
        {
            if (!canStart && Time.time > timeToStart) // Si todavía no arranco y pasó el tiempo
            {
                canStart = true; // Que puede empezar
                movementObject.SetActive(true); // Mostramos el 1er paso del Tutorial (Movimiento)
            }

            if (!movementDone && canStart) // Si no termino el Tutorial de Movimiento y puede empezar
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) // Si toca alguna tecla de Movimiento
                {
                    movementTimeToHideTimer = movementTimeToHide + Time.time; // Empezamos el Contador para Ocultar
                }

                if (Time.time > movementTimeToHideTimer) // Si paso el tiempo del Contador
                {
                    movementObject.SetActive(false); // Ocultamos el Objeto Movimiento
                    movementDone = true; // Que termino el Tutorial de Movimiento
                    dashObject.SetActive(true); // Mostramos el 2do paso del Tutorial (Dash)
                }
            }
            else if (!dashDone && movementDone) // Si no termino el Tutorial de Dash y termino el Tutorial de Movimiento
            {
                if (Input.GetButtonDown("Fire2")) // Si hace Click con el Boton Derecho del Mouse
                {
                    dashTimeToHideTimer = dashTimeToHide + Time.time; // Empezamos el Contador para Ocultar
                }

                if (Time.time > dashTimeToHideTimer) // Si paso el tiempo del Contador
                {
                    dashObject.SetActive(false); // Ocultamos el Objeto Dash
                    dashDone = true; // Que termino el Tutorial de Dash
                    healObject.SetActive(true); // Mostramos el 2do paso del Tutorial (Heal)
                }
            }
            else if (!healDone && dashDone) // Si no termino el Tutorial de Heal y termino el Tutorial de Dash
            {
                //TODO: Hacer daño al Personaje para el Tutorial
                if (Input.GetKeyDown(KeyCode.C)) // Si presiona la tecla C
                {
                    healTimeToHideTimer = healTimeToHide + Time.time; // Empezamos el Contador para Ocultar
                }

                if (Time.time > healTimeToHideTimer) // Si paso el tiempo del Contador
                {
                    healObject.SetActive(false); // Ocultamos el Objeto Heal
                    healDone = true; // Que termino el Tutorial de Heal
                    attackObject.SetActive(true); // Mostramos el 2do paso del Tutorial (Attack)
                }
            }
            else if (!attackDone && healDone) // Si no termino el Tutorial de Attack y termino el Tutorial de Heal
            {
                if (Input.GetButtonDown("Fire1")) // Si hace Click con el Boton Izquierdo del Mouse
                {
                    attackTimeToHideTimer = attackTimeToHide + Time.time; // Empezamos el Contador para Ocultar
                }

                if (Time.time > attackTimeToHideTimer) // Si paso el tiempo del Contador
                {
                    attackObject.SetActive(false); // Ocultamos el Objeto Attack
                    attackDone = true; // Que termino el Tutorial de Attack
                    Destroy(this); // Destruimos el Componente para que no siga consumiento recursos
                }
            }
        }
    }
}
