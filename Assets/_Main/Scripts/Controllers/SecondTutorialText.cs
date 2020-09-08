using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

public class SecondTutorialText : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private bool canAppear;
    
    public void Start()
    {
        canAppear = false;
        image.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            Debug.Log("this works");
            canAppear = true;
            image.SetActive(true);
        }
    }
}
