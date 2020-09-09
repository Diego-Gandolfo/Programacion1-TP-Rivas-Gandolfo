/*
 * Script que se encargará de gestionar el Tutorial
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private GameObject movementObject = null; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        private bool movementDone = false; // Indicaremos cuando completo el Tutorial de Movimiento

        [Header("Movement")]
        [SerializeField] private GameObject dashObject = null; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        private bool dashDone = false; // Indicaremos cuando completo el Tutorial de Movimiento

        [Header("Movement")]
        [SerializeField] private GameObject healObject = null; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        private bool healDone = false; // Indicaremos cuando completo el Tutorial de Movimiento

        [Header("Movement")]
        [SerializeField] private GameObject attackObject = null; // Almacenaremos el Objeto que contiene el Cartel de Movimiento
        private bool attackDone = false; // Indicaremos cuando completo el Tutorial de Movimiento

        private void Start()
        {
            movementObject.SetActive(true);
        }

        private void Update()
        {
            if (!movementDone)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    movementObject.SetActive(false);
                    movementDone = true;
                    dashObject.SetActive(true);
                }
            }
            else if (!dashDone && movementDone)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    dashObject.SetActive(false);
                    dashDone = true;
                    healObject.SetActive(true);
                }
            }
            else if (!healDone && dashDone)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    healObject.SetActive(false);
                    healDone = true;
                    attackObject.SetActive(true);
                }
            }
            else if (!attackDone && healDone)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    attackObject.SetActive(false);
                    attackDone = true;
                    Destroy(this);
                }
            }
        }
    }
}
