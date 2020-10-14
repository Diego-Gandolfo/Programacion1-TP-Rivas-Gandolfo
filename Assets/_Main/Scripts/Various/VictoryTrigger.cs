using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class VictoryTrigger : MonoBehaviour
    {
        public Action OnVictory;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnVictory.Invoke();
            }
        }
    }
}
