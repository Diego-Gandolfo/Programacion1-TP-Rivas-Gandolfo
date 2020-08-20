/*
 * Script que usaremos para Configurar la Pantalla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private int width = 1920; // Tamaño en Pixeles del Ancho de la Pantala
        [SerializeField] private int height = 1080; // Tamaño en Pixeles del Alto de la Pantalla
        [SerializeField] private bool fullScreen = true; // Si se ejecuta en Pantalla Completa
        [SerializeField] private int refreshRate = 60; // Si no entiendo mal, eso son los FPS que se ejecutará el juego

        private void Start()
        {
            ChangeScreenSettings(); // Al Iniciar, aplicamos la Configuracíon predeterminada
        }

        public void ChangeScreenSettings() // Si fuese necesario, se pueden cambiar los valores y volver a cambiar la configuracion
        {
            Screen.SetResolution(width, height, fullScreen, refreshRate); // Configuramos la Resolucion
        }
    }
}
