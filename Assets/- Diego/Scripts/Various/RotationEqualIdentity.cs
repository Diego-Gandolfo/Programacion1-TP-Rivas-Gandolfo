using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class RotationEqualIdentity : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Quaternion.identity; // Forzamos a que siempre la rotación sea 0 (cero) con respecto al Mundo para evitar que un Objeto Hijo rote
        }
    }
}
