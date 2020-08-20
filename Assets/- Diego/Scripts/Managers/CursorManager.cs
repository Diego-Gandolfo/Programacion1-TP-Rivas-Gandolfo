/*
 * Script que usaremos para Configurar el puntero del Mouse
 * 
 * Podemos variar las Configuraciones y aplicarlas con ChangeCursorSettings()
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private bool cursorVisible = true; // Variable para determinar si el puntero de Mouse es visible

        private void Start()
        {
            ChangeCursorSettings(); // Al inicio aplicamos las Configuraciones
        }

        public void ChangeCursorSettings() // Funcion para aplicar las modificaciones a las Configuraciones
        {
            Cursor.visible = cursorVisible; // Actualizamos si el cursor es visible o no
        }
    }
}
