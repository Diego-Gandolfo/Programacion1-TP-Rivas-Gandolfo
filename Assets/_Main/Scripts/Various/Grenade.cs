using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Grenade : MonoBehaviour
    {
        public bool hasGrenade;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                hasGrenade = true;
            }
            else
            {
                hasGrenade = false;
            }
        }
    }
}
