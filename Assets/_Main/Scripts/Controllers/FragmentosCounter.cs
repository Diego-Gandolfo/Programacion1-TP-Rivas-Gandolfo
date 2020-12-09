using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace OnceUponAMemory.Main
{
    public class FragmentosCounter : MonoBehaviour
    {
        TextMeshProUGUI CounterText;
        public static int Amount;
        private GameManager gameManager = null;
        private Scene scene;

        private void Awake()
        {
            scene = SceneManager.GetActiveScene();
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.SetFragmentosCounter(this);
        }

        void Start()
        {
            CounterText = GetComponent<TextMeshProUGUI>(); // Lo cambie por un MeshPro

            if (scene.name == "Level" || scene.name == "TutorialScene")
            {
                Amount = 0;
            }
            else if (scene.name == "SecondLevel")
            {
                int fragments = gameManager.GetFragmentSaved();

                if (Amount != fragments)
                {
                    Amount = fragments;
                }
            }
        }

        void Update()
        {
            if (CounterText != null) CounterText.text = Amount.ToString(); // Solo le puse un chequeo por las dudas
        }

        public int GetAmount()
        {
            return Amount;
        }
    }
}
