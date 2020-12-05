using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OnceUponAMemory.Main
{
    public class GameManager : MonoBehaviour
    {
        private VictoryTrigger victoryTrigger = null; // Objeto que tiene la Condicion de Victoria
        private PlayerHealth playerHealth = null; // Objeto que tiene la condicion de Derrota
        private string sceneToLoad = "";

        private void GameOver()
        {
            SceneManager.LoadScene("GameOver"); // Cargamos escena de GameOver
        }

        private void Victory()
        {
            print("EventVictory");
            sceneToLoad = victoryTrigger.GetSceneName();
            SceneManager.LoadScene(sceneToLoad); // Cargamos el segundo nivel
        }

        public void SetVictoryTrigger(VictoryTrigger trigger)
        {
            victoryTrigger = trigger;
            victoryTrigger.OnVictory += Victory; // Escuchamos el Evento de OnVictory invocado en VictoryTrigger y llamamos a la funcion Victory
        }

        public void SetPlayerHealth(PlayerHealth player)
        {
            playerHealth = player;
            playerHealth.OnDie += GameOver; // Escuchamos el Evento de OnDie invocado en PlayerHealth y llamamos a la funcion GameOver
        }
    }
}
