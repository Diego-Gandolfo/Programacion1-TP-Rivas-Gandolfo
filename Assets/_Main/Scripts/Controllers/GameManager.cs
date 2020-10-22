using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OnceUponAMemory.Main
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private VictoryTrigger victoryTrigger = null; // Objeto que tiene la Condicion de Victoria
        [SerializeField] private PlayerHealth playerHealth = null; // Objeto que tiene la condicion de Derrota

        private void Awake()
        {
            victoryTrigger.OnVictory += Victory; // Escuchamos el Evento de OnVictory invocado en VictoryTrigger y llamamos a la funcion Victory
            playerHealth.OnDie += GameOver; // Escuchamos el Evento de OnDie invocado en PlayerHealth y llamamos a la funcion GameOver
        }

        private void GameOver()
        {
            SceneManager.LoadScene("GameOver"); // Cargamos escena de GameOver

        }

        private void Victory()
        {
            SceneManager.LoadScene("Victory"); // Cargamos escena de Victoria
        }
    }
}
