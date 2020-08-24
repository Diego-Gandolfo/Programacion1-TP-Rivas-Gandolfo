﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class FragmentosScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerHealth TopDownCharacter = collision.GetComponent<PlayerHealth>();
            if (TopDownCharacter != null)
            {
                Debug.Log("Im Being Collected");
                CounterScript.Amount += 1;
                SoundManager.PlaySound("ItemPickUp");
                Destroy(gameObject);
            }

        }
    }
}
