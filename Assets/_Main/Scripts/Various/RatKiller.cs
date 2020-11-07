using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKiller : MonoBehaviour
{
    [SerializeField] private GameObject rat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //como destruir una instancia de un prefab?
        }    
    }
}
