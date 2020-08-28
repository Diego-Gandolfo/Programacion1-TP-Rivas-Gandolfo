﻿using System.Collections;
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

        public Animator animator;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
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
    }
}
