/*
 * Este Script lo que hace es que el Objeto al que se lo asigna mire a donde está el puntero del Mouse
 * 
 * Funciona para Objetos 2D
*/ 

using UnityEngine;
using System.Collections;

namespace OnceUponAMemory.Main
{
    public class LookAtMouse2D : MonoBehaviour
    {
        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse

            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); // Calculamos la dirección a la que hay que mirar

            transform.up = direction; // Actualizamos el Transform para que mire al puntero del Mouse
        }
    }
}
