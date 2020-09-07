using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;
using UnityEngine.UI;

public class SecondTutorialTrigger : MonoBehaviour
{
    [SerializeField] private Text secondTutorialText;

    private void Start()
    {
        secondTutorialText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            //secondTutorialText.gameObject.SetActive(true);
            Debug.Log("lol");
        }
        
    }
}
