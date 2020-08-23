﻿/*
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

        private void Update()
        {
            // Movimiento
            float speedMovVer = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; // Almacenamos el Eje Vertical multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime
            float speedMovHor = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; // Almacenamos el Eje Horizontal multiplicando por la Velocidad de Movimiento y lo normalizamos con Time.deltaTime

            transform.Translate(0, speedMovVer, 0); // Nos movemos en el Eje Vertical
            transform.Translate(speedMovHor, 0, 0); // Nos movemos en el Eje Horizontal
        }
    }
}