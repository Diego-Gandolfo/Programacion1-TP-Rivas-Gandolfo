using System;
using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;

public class SecondTutorialText : MonoBehaviour
{
    [SerializeField] private GameObject image = null;
    //[SerializeField] private bool canAppear = false; // Esta variable no sé si la tenes pensada para algo, pero de momento no hace nada. La inicializas en FALSE en el Start y la pasas a TRUE en el OnTriggerEnter, pero no haces nada con ese valor.
    
    public void Start()
    {
        //canAppear = false;
        image.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            Debug.Log("this works");
            //canAppear = true;
            image.SetActive(true);
        }
    }
}
