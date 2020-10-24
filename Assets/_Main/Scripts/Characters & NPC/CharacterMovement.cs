/*
 * Script para controlar el Movimiento del Personaje
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 7; // Configuramos la Velocidad de Movimiento
        [SerializeField] private Animator animatorMovement = null; // Almacenaremos el Animator que contiene las Animaciones de Movimiento

        [SerializeField] private ParticleSystem dustPS = null;

        private Rigidbody2D myRigidbody2D = null;

        private void Awake()
        {
            myRigidbody2D = GetComponent<Rigidbody2D>();
        }
 
        private void Update()
        {
            /*
            // Movimiento por Transltate
            Vector2 speedMov = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime); // Almacenamos el Eje Vertical y el Eje Horizontal multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime
            transform.Translate(speedMov); // Nos movemos en el Eje Vertical y Horizontal
            
            animatorMovement.SetFloat("Speed", speedMov.sqrMagnitude); // Definimos si se está Moviendo o no

            if (speedMov.magnitude != 0) CreateDust();
            */
        }

        private void FixedUpdate()
        {

            // Movement por Rigidbody.velocity
            float xMovement = Input.GetAxis("Horizontal") * (movementSpeed);
            float yMovement = Input.GetAxis("Vertical") * (movementSpeed);

            Vector2 movement = new Vector2(xMovement, yMovement);

            myRigidbody2D.velocity = movement;
            animatorMovement.SetFloat("Speed", movement.sqrMagnitude);
            if (xMovement != 0 || yMovement != 0) CreateDust();

        }

        private void CreateDust()
        {
            dustPS.Play();
        }
    }
}
