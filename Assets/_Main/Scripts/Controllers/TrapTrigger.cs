using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public bool activateTrap = false;

    public GameObject trap;
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
}
