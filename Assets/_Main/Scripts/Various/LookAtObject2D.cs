/*
 * Este Script lo que hace es que el Objeto al que se lo asigna mire a donde está el Objeto con un determinado Tag
 * 
 * Funciona para Objetos 2D
 * 
 * Si hay varios Objetos con el mismo Tag podría no funcionar correctamente
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class LookAtObject2D : MonoBehaviour
    {
        [SerializeField] private GameObject target = null; // Alacenaremos el Objeto con el Tag a mirar

        private void Update()
        {
            if (target != null)
            {
                Vector2 direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y); // Calculamos la dirección a la que hay que mirar

                transform.up = direction; // Actualizamos el Transform para que mire al Objeto con el Tag elegido
            }
        }
    }
}
