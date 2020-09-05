using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class TrapTrigger : MonoBehaviour
    {
        [SerializeField] private bool activateTrap;

        [SerializeField] private GameObject trap;
        private void Start()
        {
            activateTrap = false;
            trap.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                activateTrap = true;
                trap.gameObject.SetActive(true);
            }
            else
            {
                activateTrap = false;
                trap.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                activateTrap = false;
                trap.gameObject.SetActive(false);
            }
        }
    }
}
