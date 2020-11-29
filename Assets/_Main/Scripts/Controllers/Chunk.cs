using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField]
        private ChunkChain key;

        [SerializeField]
        private PlayerHealth playerHealth;

        public float damage = 2.0f;

        private bool canDamage = true;

        private float timeToDamage = 2.0f;
        private float currentTimeToDamage = 0.0f;

        private void Start()
        {
            canDamage = true;
        }

        private void Update()
        {
            if (!canDamage)
            {
                currentTimeToDamage += Time.deltaTime;

                if (currentTimeToDamage >= timeToDamage)
                {
                    canDamage = true;
                }
                    
            }
            
            else
                canDamage = false;
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !key.hasBlockKey)
            {
                if (canDamage)
                {
                    playerHealth.TakeDamage(damage);
                    canDamage = false;

                    currentTimeToDamage = 0.0f;
                }
            }

            else if (collision.gameObject.CompareTag("Player") && key.hasBlockKey)
            {
                Debug.Log("now you can");
            }
        }
    }
}
