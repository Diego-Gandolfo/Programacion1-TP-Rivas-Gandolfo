using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class DamageArea : MonoBehaviour
    {
        private int damage = 2;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerHealth TopDownCharacter = collision.transform.GetComponent<PlayerHealth>();
            if (TopDownCharacter != null)
            {
                TopDownCharacter.TakeDamage(damage);
                Debug.Log("im taking damage");
            }

        }
    }
}
