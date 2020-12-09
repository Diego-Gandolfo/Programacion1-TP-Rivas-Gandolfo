using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OnceUponAMemory.Main
{
    public class LevelManager : MonoBehaviour
    {
        private Scene scene;
        private GameManager gameManager = null;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            scene = SceneManager.GetActiveScene();
        }

        private void Start()
        {
            gameManager.SetLastLevel(scene.name);
            print(scene.name);
        }
    }
}
