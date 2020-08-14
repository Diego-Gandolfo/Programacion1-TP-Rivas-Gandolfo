/*
 * Este Script lo vamos a usar para Configurar la Escena
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void Load_Scene(string sceneName) // Función para cargar una nueva Escena, útil en las Escenas de Menu
    {
        SceneManager.LoadScene(sceneName); // Cargamos la Escena deseada
    }
}
