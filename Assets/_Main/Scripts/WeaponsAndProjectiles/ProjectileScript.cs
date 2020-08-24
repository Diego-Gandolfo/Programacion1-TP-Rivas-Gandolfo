using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using UnityEngine;
using Health = OnceUponAMemory.Diego.Health;

namespace OnceUponAMemory.Main
{
    public class ProjectileScript : MonoBehaviour
    {
        public float speed;
        private Transform player;
        private Vector2 target;

        private int damage = 1;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            target = new Vector2(player.position.x, player.position.y);
        }


        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
                DestroyProjectile();
        }

        private void OnTriggerEnter2D(Collider2D Other)
        {
            if (Other.CompareTag("Player"))
            {
                DestroyProjectile();
                Debug.Log("destroyed");
            }

            PlayerHealth TopDownCharacter = Other.transform.GetComponent<PlayerHealth>();
            if (TopDownCharacter != null)
            {
                TopDownCharacter.TakeDamage(damage);
            }
        }

        void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    }

}
