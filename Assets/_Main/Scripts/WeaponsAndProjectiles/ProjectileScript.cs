using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;
using Health = OnceUponAMemory.Diego.Health;

namespace OnceUponAMemory.Main
{
    public class ProjectileScript : MonoBehaviour
    {
        [SerializeField] private float impulse = 10f;
        public float speed;
        private Transform player;
        private Vector2 target;

        private int damage = 1;

        private Rigidbody2D rb2D = null;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Esto quizás habría que cambiarlo porque dijeron que no es recomendable de usar

            target = new Vector2(player.position.x, player.position.y);

            Vector2 direction = (Vector3)target - transform.position;
            rb2D.AddForce(direction.normalized * impulse, ForceMode2D.Impulse);
        }


        void Update()
        {
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
                DestroyProjectile();
        }

        private void FixedUpdate()
        {
        }

        private void OnTriggerEnter2D(Collider2D Other)
        {/*
            if (Other.CompareTag("Player"))
            {
                DestroyProjectile();
                //Debug.Log("destroyed");
            }*/

            PlayerHealth TopDownCharacter = Other.transform.GetComponent<PlayerHealth>();

            if (TopDownCharacter != null)
            {
                TopDownCharacter.TakeDamage(damage);
            }

            DestroyProjectile();
        }

        void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    }

}
