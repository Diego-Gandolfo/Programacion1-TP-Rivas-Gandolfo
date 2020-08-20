/*
 * Este Script lo vamos a usar para Configurar la Escena
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnceUponAMemory.Diego
{
    public class SceneManager : MonoBehaviour
    {
        public void Load_Scene(string sceneName) // Función para cargar una nueva Escena, útil en las Escenas de Menu
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // Cargamos la Escena deseada
        }
    }
}
