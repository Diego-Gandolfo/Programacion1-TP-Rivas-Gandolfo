using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class VictoryTrigger : MonoBehaviour
    {
        [SerializeField] private string sceneName = "";
        private GameManager gameManager = null;

        public Action OnVictory;

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.SetVictoryTrigger(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnVictory.Invoke();
            }
        }

        public string GetSceneName()
        {
            return sceneName;
        }
    }
}
