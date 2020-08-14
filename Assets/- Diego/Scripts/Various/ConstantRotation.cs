/*
 * Este Script es bastante básico, pero lo comento igualmente.
 * 
 * Lo que hace es
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public Vector3 speedRotation; // Variable para asignar la Velocidad de Rotacion en los 3 Ejes

    void Update()
    {
        Vector3 rotation = speedRotation * Time.deltaTime; // Variable para normalizar con Time.deltaTime la Velocidad de Rotacion

        transform.Rotate(rotation); // Rotamos el Objeto
    }
}
