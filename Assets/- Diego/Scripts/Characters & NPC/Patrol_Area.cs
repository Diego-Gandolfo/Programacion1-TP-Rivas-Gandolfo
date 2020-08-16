using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Area : MonoBehaviour
{
    public bool random = false; // Variable para determinar si se mueve de forma aleatoria o secuencial

    public float movemetSpeed = 3.0f; // La velocidad que se desplaza al estar patrullando
    public float waitTime = 1.0f; // El tiempo que espera hasta en un punto antes de empezar a moverse al siguiente
    private float timer = 0.0f; // Variable que usaremos para llevar el control del tiempo

    public Transform patrolPoint; // Variable donde almacenaremos el centro del punto a patrullar
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        patrolPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        timer = waitTime; // Inicializamos el contador al tiempo de espera deseado
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, movemetSpeed * Time.deltaTime); // Nos movemos al punto indicado (randomPoint)

        if (Vector2.Distance(transform.position, patrolPoint.position) < 0.2f) // Nos fijamos si ya estamos cerca del punto indicado (randomPoint)
        {
            if (timer <= 0) // Comprobamos si ya paso el tiempo de espera deseado
            {
                patrolPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                timer = waitTime;
            }
            else
            {
                timer -= Time.deltaTime; // Si el tiempo no paso, vamos restando Time.deltaTime
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (patrolPoint != null) Gizmos.DrawWireCube(patrolPoint.position, new Vector3(((minX + maxX) / 2), ((minY + maxY) / 2), 10));
    }
}
