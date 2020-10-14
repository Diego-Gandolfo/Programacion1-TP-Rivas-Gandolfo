using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OnceUponAMemory.Main
{
    public class GameManager : MonoBehaviour
    {
        // Condicion Victoria: Llegar al final del mapa y activar el WinTrigger
        // Condicion Derrota: Morir

        [SerializeField] private VictoryTrigger victoryTrigger;
        [SerializeField] private PlayerHealth playerHealth;

        private void Awake()
        {
            victoryTrigger.OnVictory += Victory;
            playerHealth.OnDie += GameOver;
        }

        private void GameOver()
        {
            SceneManager.LoadScene("GameOver");

        }

        private void Victory()
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
