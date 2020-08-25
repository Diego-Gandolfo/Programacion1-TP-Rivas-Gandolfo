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
        // Variables de Movimiento
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

            // Esto es para probar los Blend Tree, pero la idea es que funcione apuntando a donde esté el Mouse y no en el sentido que se mueve
            animator.SetFloat("Horizontal", speedMov.x);
            animator.SetFloat("Vertical", speedMov.y);
            animator.SetFloat("Speed", speedMov.sqrMagnitude);
        }
    }
}
