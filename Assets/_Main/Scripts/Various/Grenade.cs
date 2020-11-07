using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float explosionTime = 2.0f;
        private float currentExplosionTime = 0f;

        [SerializeField] private float explosionRadius = 0f;
        [SerializeField] private float explosionIntensity = 0f;

        [SerializeField] private LayerMask layerMasks = 0;

        [SerializeField] private GameObject stone = null;
        
        public bool hasGrenade;

        private void Update()
        {
            currentExplosionTime += Time.deltaTime;

            if(currentExplosionTime >= explosionTime)
            {
                Explode();
            }
        }

        void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, explosionRadius, layerMasks);

            foreach(var collider in colliders)
            {
                Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();

                if(rb != null)
                {
                    Vector3 direction = collider.transform.position - transform.position;
                    //float distance = direction.magnitude;
                    direction.Normalize();

                    rb.AddForce((direction * explosionIntensity), ForceMode2D.Impulse);
                    Destroy(gameObject);

                    stone.gameObject.SetActive(false);
                }


            }
        }



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
