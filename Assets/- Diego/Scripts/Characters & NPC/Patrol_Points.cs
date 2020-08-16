using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Points : MonoBehaviour
{
    public bool random = false; // Variable para determinar si se mueve de forma aleatoria o secuencial

    public float movemetSpeed = 3.0f; // La velocidad que se desplaza al estar patrullando
    public float waitTime = 1.0f; // El tiempo que espera hasta en un punto antes de empezar a moverse al siguiente
    private float timer = 0.0f; // Variable que usaremos para llevar el control del tiempo

    public Transform[] patrolPoints; // Array (vector o "lista") donde almacenaremos los puntos a patrullar
    private int randomPoint = 0; // Variable que usaremos para asignar un punto aleatorio de patrullaje
    private int currentPoint = 0; // Variable que usaremos para saber en que punto de patrullaje debemos usar

    private void Start()
    {
        randomPoint = Random.Range(0, patrolPoints.Length); // Inicializamos un punto aleatorio
        currentPoint = 0; // Inicializamos el punto de comienzo para cuando recorremos de forma secuencial
        timer = waitTime; // Inicializamos el contador al tiempo de espera deseado
    }

    private void Update()
    {
        if (random) // Si random es TRUE es que queremos que se mueva de forma aleatoria
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, movemetSpeed * Time.deltaTime); // Nos movemos al punto indicado (randomPoint)

            if (Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f) // Nos fijamos si ya estamos cerca del punto indicado (randomPoint)
            {
                if (timer <= 0) // Comprobamos si ya paso el tiempo de espera deseado
                {
                    randomPoint = Random.Range(0, patrolPoints.Length); // Asignamos un nuevo punto aleatorio
                    timer = waitTime;
                }
                else
                {
                    timer -= Time.deltaTime; // Si el tiempo no paso, vamos restando Time.deltaTime
                }
            }
        }
        else if (!random) // Si random es FALSE es que queremos que se mueva de forma secuencial
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position, movemetSpeed * Time.deltaTime); // Nos movemos al punto indicado (currentPoint)

            if (Vector2.Distance(transform.position, patrolPoints[currentPoint].position) < 0.2f) // Nos fijamos si ya estamos cerca del punto indicado (currentPoint)
            {
                if (timer <= 0) // Comprobamos si ya paso el tiempo de espera deseado
                {
                    currentPoint++; // Vamos al siguiente punto

                    if (currentPoint >= patrolPoints.Length) // Nos fijamos si el siguiente punto se sale del rango del Array
                    {
                        currentPoint = 0; // Volvemos el currentPoint al punto de inicio
                    }

                    timer = waitTime; // Reseteamos el contador
                }
                else
                {
                    timer -= Time.deltaTime; // Si el tiempo no paso, vamos restando Time.deltaTime
                }
            }
        }
    }
}
