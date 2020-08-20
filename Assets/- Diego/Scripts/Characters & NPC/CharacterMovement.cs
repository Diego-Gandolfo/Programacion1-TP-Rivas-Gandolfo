/*
 * Script para controlar el Movimiento del Personaje
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class CharacterMovement : MonoBehaviour
    {
        // Variables de Movimiento
        [SerializeField] private float movementSpeed = 7; // Configuramos la Velocidad de Movimiento
        [SerializeField] private float runMultiplier = 3; // Configuramos un Multiplicador para cuando corre

        private void Update()
        {
            // Movimiento
            float speedMovVer = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; // Almacenamos el Eje Vertical multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime
            if (Input.GetKey(KeyCode.LeftShift)) speedMovVer *= runMultiplier; // Si presiona el Shift Izquierdo aplicamos el Multiplicador de Velocidad para que corra

            float speedMovHor = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; // Almacenamos el Eje Horizontal multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime
            if (Input.GetKey(KeyCode.LeftShift)) speedMovHor *= runMultiplier; // Si presiona el Shift Izquierdo aplicamos el Multiplicador de Velocidad para que corra

            transform.Translate(0, speedMovVer, 0); // Nos movemos en el Eje Vertical
            transform.Translate(speedMovHor, 0, 0); // Nos movemos en el Eje Horizontal
        }
    }
}
