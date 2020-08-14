using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public float retreatDistance;
    public Transform player;

    private float timeBetweenShots;
    public float starTimeBetweentShots;

    public GameObject projectile;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = starTimeBetweentShots;
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

        //SI EL TIEMPO ENTRE DISPAROS ES MENOR O IGUAL A 0 SE INSTANCIA EL PROYECTIL Y ESTE TIEMPO ENTRE DISPAROS QUEDA IGUAL AL "EMPEZAR EL TIEMPO ENTRE DISPAROS"
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = starTimeBetweentShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
