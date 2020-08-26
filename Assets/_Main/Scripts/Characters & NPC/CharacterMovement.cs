/*
 * Script para controlar el Movimiento del Personaje
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 7; // Configuramos la Velocidad de Movimiento
        private Animator animator;

        private void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            // Movimiento
            Vector2 speedMov = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime); // Almacenamos el Eje Vertical y el Eje Horizontal multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime
            transform.Translate(speedMov); // Nos movemos en el Eje Vertical y Horizontal
            animator.SetFloat("Speed", speedMov.sqrMagnitude);
        }
    }
}
