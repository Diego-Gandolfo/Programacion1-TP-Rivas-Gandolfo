using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class GrenadeBehavior : MonoBehaviour
    {
        [Header("Physics")]
        [SerializeField] private float stopVelocity = 0f;
        private Rigidbody2D rb2D = null;

        [Header("Timer")]
        [SerializeField] private float explotionTimer = 0f;
        private float timer = 0f;
        private bool canCount = false;
        private bool doOnce = true;

        [Header("Explotion")]
        [SerializeField] private float explotionRadius = 0f;
        [SerializeField] private float explotionIntensity = 0f;
        [SerializeField] private float explotionDamage = 0f;
        [SerializeField] private LayerMask explotionLayerMask = 0;
        [SerializeField] private GameObject explotionParticleEffect = null;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (canCount && (timer <= 0))
            {
                Explotion();
            }
            else if (canCount && (timer > 0))
            {
                timer -= Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (doOnce && (rb2D.velocity.magnitude < stopVelocity))
            {
                doOnce = false;
                rb2D.velocity = Vector2.zero;
                timer = explotionTimer;
                canCount = true;
            }
        }

        public void ThrowGrenade(Vector2 dir, float imp)
        {
            rb2D.AddForce(dir * imp, ForceMode2D.Impulse);
        }

        private void Explotion()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explotionRadius, explotionLayerMask);

            foreach (var collider in colliders)
            {
                Rigidbody2D rigidbody2D = collider.gameObject.GetComponent<Rigidbody2D>();

                if (rigidbody2D != null)
                {
                    Vector3 direction = collider.transform.position - transform.position;
                    float distance = direction.magnitude;
                    direction.Normalize();

                    rigidbody2D.AddForce((direction * explotionIntensity) / distance, ForceMode2D.Impulse);
                }

                Health lifeController = collider.gameObject.GetComponent<Health>();

                if (lifeController != null)
                {
                    float distance = Vector2.Distance(collider.transform.position, transform.position);

                    lifeController.TakeDamage((distance * explotionDamage) / explotionRadius);
                }

                ResizeByHealth resizeByHealth = collider.gameObject.GetComponent<ResizeByHealth>();

                if (resizeByHealth != null)
                    resizeByHealth.Resize();       
            }

            Instantiate(explotionParticleEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
