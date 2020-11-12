﻿using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class RatKiller : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("acá hay un enemy");
                Destroy(collision.gameObject);
                Debug.Log("destruir");
            }
        }
    }
}


