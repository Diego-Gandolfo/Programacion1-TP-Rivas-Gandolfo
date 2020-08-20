/*
 * Este Script es bastante básico, pero lo comento igualmente.
 * 
 * Lo que hace es Rotar un Objeto constantemente
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class ConstantRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 speedRotation; // Variable para asignar la Velocidad de Rotacion en los 3 Ejes

        void Update()
        {
            Vector3 rotation = speedRotation * Time.deltaTime; // Variable para normalizar con Time.deltaTime la Velocidad de Rotacion

            transform.Rotate(rotation); // Rotamos el Objeto
        }
    }
}
