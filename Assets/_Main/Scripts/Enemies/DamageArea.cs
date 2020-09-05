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
        private float nextDamage;

        private void Update()
        {
            //ACÁ INTENTÉ APLICAR UN POCO LO QUE VIMOS EN CLASE, PERO AÚN ASÍ NO FUNCIONA COMO YO QUISIERA.

            //nextDamage += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            PlayerHealth player = other.transform.GetComponent<PlayerHealth>();

            if (player != null && Time.time >= nextDamage)
            {
                player.TakeDamage(damage);
                
                nextDamage = Time.time + 1f / damageRate;
            }
        }
    }
}
