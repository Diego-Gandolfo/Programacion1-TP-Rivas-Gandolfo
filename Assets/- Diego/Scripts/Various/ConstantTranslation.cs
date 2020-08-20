/*
 * Este Script es bastante básico, pero lo comento igualmente.
 * 
 * Lo que hace es Mover un Objetoc constantemente
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class ConstantTranslation : MonoBehaviour
    {
        [SerializeField] private Vector3 speedTranslation; // Variable para asignar la Velocidad de Movimiento en los 3 Ejes

        void Update()
        {
            Vector3 translation = speedTranslation * Time.deltaTime; // Variable para normalizar con Time.deltaTime la Velocidad de Movimiento

            transform.Translate(translation); // Movemos el Objeto
        }
    }
}
