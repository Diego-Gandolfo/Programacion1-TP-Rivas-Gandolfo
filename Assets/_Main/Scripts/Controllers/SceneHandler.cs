using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnceUponAMemory.Main
{
    public class SceneHandler : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
