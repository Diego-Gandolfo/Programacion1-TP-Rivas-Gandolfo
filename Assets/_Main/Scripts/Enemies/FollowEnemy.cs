using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FollowEnemy : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private float stopDistance = 3;
        [SerializeField] private float retreatDistance = 2;

        public Transform player;

        public Animator animator; // Está variable acá no sé usa, la accedes desde otro lado?

        void Start()
        {
            //if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player == null) Debug.LogError($"{this} en {this.gameObject} no tiene asignado el Player");
        }

        void Update()
        {
            //SE CHEQUEA SI LA DISTANCIA EN LA QUE ESTÁ EL JUGADOR ES MAYOR A LA "STOP DISTANCE"
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            //SE CHEQUEA LO DE ANTES Y TAMBIÉN QUE SEA MAYOR QUE LA DISTANCIA DE RETREAR
            else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            //SI ES MENOR QUE LA DISTANCIA DE RETREAT, SE MUEVE CON VELOCIDAD NEGATIVA
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else
            {
                transform.up = new Vector2(0, 0);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null) rb.velocity = Vector2.zero;
            }
        }
    }
}
