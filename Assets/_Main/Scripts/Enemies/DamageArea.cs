using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class DamageArea : MonoBehaviour
    {
        private int damage = 2;
        public float damageRate = 2f;
        private float nextDamage = 0f;

        /*private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerHealth TopDownCharacter = collision.transform.GetComponent<PlayerHealth>();
            if (TopDownCharacter != null)
            {
                TopDownCharacter.TakeDamage(damage);
                Debug.Log("im taking damage");
            }
        }
        */
        
        //QUERÍA HACER QUE EL DAÑO FUERA CON ON TRIGGER STAY, PERO POR AHORA NO FUNCIONA!
        private void OnTriggerStay(Collider other)
        {
            PlayerHealth Player = other.transform.GetComponent<PlayerHealth>();
            if (Player != null && Time.time >= nextDamage)
            {
                Player.TakeDamage(damage);
                nextDamage = Time.time + 1f / damageRate;
                Debug.Log("im damage");
            }
        }
    }
}
