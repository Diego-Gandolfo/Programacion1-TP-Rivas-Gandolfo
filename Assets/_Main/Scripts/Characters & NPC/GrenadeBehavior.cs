using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class GrenadeBehavior : MonoBehaviour
    {
        [Header("Physics")]
        [SerializeField] private float stopVelocityMagnitude = 0f;
        [SerializeField] private float angularVelocityReduction = 0f;
        [SerializeField] private float inertia = 0f;
        private Rigidbody2D rb2D = null;
        private Vector2 lastVelocity = Vector2.zero;

        [Header("Timer")]
        [SerializeField] private float explotionTimer = 0f;
        private float timer = 0f;
        private bool canCount = false;
        private bool doOnce = false;

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
            lastVelocity = rb2D.velocity; // Capturamos la velocidad actual y la guardamos como la ultima velocidad registrada

            if (doOnce && Mathf.Abs(rb2D.velocity.magnitude) < stopVelocityMagnitude && Mathf.Abs(lastVelocity.magnitude) < stopVelocityMagnitude)
            {
                doOnce = false;
                rb2D.velocity = Vector2.zero;
                timer = explotionTimer;
                canCount = true;
            }

            if (canCount)
                if (rb2D.angularVelocity >= 0)
                    rb2D.angularVelocity -= angularVelocityReduction;
        }

        public void ThrowGrenade(Vector2 dir, float imp)
        {
            doOnce = true;
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

                    if ((explotionRadius - distance) > 0)
                        lifeController.TakeDamage((explotionRadius - distance) * (explotionDamage / explotionRadius));
                    //lifeController.TakeDamage((distance * explotionDamage) / explotionRadius); // Formula vieja que funcionaba mal
                }
                else
                {
                    EnemyHealth lifeController2 = collider.gameObject.GetComponent<EnemyHealth>();

                    if (lifeController2 != null)
                    {
                        float distance = Vector2.Distance(collider.transform.position, transform.position);

                        if ((explotionRadius - distance) > 0)
                            lifeController2.TakePlayerDamage((explotionRadius - distance) * (explotionDamage / explotionRadius));
                        //lifeController.TakeDamage((distance * explotionDamage) / explotionRadius); // Formula vieja que funcionaba mal
                    }
                }

                ResizeByHealth resizeByHealth = collider.gameObject.GetComponent<ResizeByHealth>();

                if (resizeByHealth != null)
                    resizeByHealth.Resize();
            }

            Instantiate(explotionParticleEffect, transform.position, Quaternion.identity);

            //
            SoundManager.PlaySound("ShortExplosion");

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            var speed = inertia == 0 ? 0 : lastVelocity.magnitude / inertia; // Almacenamos en speed la mitad de la magnitud de la Velocity actual
            var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal); // Calculamos la nueva dirección

            if (collision.gameObject.CompareTag("Enemy")) speed /= 2;

            rb2D.velocity = direction * speed; // Hacemos que la velocity sea igual a la nueva dirección * speed

            //Instantiate(projectileReflectEffect, transform.position, Quaternion.identity); // No me gusto como quedo el Efecto

            //OnProjectileReflect?.Invoke(); // No me gusto como quedo el sonido
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere((Vector2)transform.position, explotionRadius);
        }
    }
}
