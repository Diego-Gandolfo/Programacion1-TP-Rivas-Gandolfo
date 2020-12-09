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
        private FragmentosCounter fragmentosCounter = null;
        private string sceneToLoad = "";
        private string lastLevel;
        private int fragmentsSaved = 0;

        private void GameOver()
        {
            SceneManager.LoadScene("GameOver"); // Cargamos escena de GameOver
        }

        private void Victory()
        {
            print("EventVictory");
            fragmentsSaved = fragmentosCounter.GetAmount();
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

        public void SetFragmentosCounter(FragmentosCounter counter)
        {
            fragmentosCounter = counter;
        }

        public void SetLastLevel(string scene)
        {
            lastLevel = scene;
        }

        public string GetLastLevel()
        {
            return lastLevel;
        }

        public void SetFragmentSaved(int amount)
        {
            fragmentsSaved = amount;
        }

        public int GetFragmentSaved()
        {
            return fragmentsSaved;
        }
    }
}
