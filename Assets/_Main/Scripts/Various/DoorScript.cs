using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class DoorScript : MonoBehaviour
    {
        public bool hasKey;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !hasKey)
                Debug.Log("you need a key");

            else if (other.CompareTag("Player") && hasKey)
                Debug.Log("you can pass now");

        }
    }
}
