using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnceUponAMemory.Main
{
    public class SceneHandler : MonoBehaviour
    {
        private GameManager gameManager = null;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        public void LoadSceneByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadLastLevel()
        {
            string level = gameManager.GetLastLevel();
            print(level);
            SceneManager.LoadScene(level);
        }
    }
}
