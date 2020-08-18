using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Area : MonoBehaviour
{
    public float movemetSpeed = 3.0f; // La velocidad que se desplaza al estar patrullando
    public float waitTime = 1.0f; // El tiempo que espera hasta en un punto antes de empezar a moverse al siguiente
    private float timer = 0.0f; // Variable que usaremos para llevar el control del tiempo

    public Transform patrolPoint; // Variable donde almacenaremos el centro del punto a patrullar
    public float minX; // Cuantas unidades se puede mover hacia la izquierda de patrolPoint
    public float maxX; // Cuantas unidades se puede mover hacia la derecha de patrolPoint
    public float minY; // Cuantas unidades se puede mover hacia la abajo de patrolPoint
    public float maxY; // Cuantas unidades se puede mover hacia la arriba de patrolPoint

    private float relativelMinX; // Para almacenar el valor minX relativo, sin perder el valor de minX original
    private float relativeMaxX; // Para almacenar el valor maxX relativo, sin perder el valor de maxX original
    private float relativeMinY; // Para almacenar el valor minY relativo, sin perder el valor de minY original
    private float relativeMaxY; // Para almacenar el valor maxY relativo, sin perder el valor de maxY original

    private float widthSquere; // Para almacenar el ancho del area
    private float heightSquere; // Para almacenar el alto del area
    private Vector3 positionSquere; // Almacenaremos la posicion del patrolPoint al activar el Objeto o el Componente

    public float minDistance; // Distancia minima que tiene que haber entre al

    private void OnEnable() // Cada vez que se activa el Objeto o el Componente
    {
        positionSquere = patrolPoint.position; // Inicializamos la posicion del patrolPoint
        widthSquere = Mathf.Abs(minX) + Mathf.Abs(maxX) + gameObject.transform.localScale.x; // Inicializamos el ancho del Area
        heightSquere = Mathf.Abs(minY) + Mathf.Abs(maxY) + gameObject.transform.localScale.y; // Inicializamos el alto del Area

        relativelMinX = minX + patrolPoint.position.x; // Inicializamos el valor relativo de minX
        relativeMaxX = maxX + patrolPoint.position.x; // Inicializamos el valor relativo de maxX
        relativeMinY = minY + patrolPoint.position.y; // Inicializamos el valor relativo de minY
        relativeMaxY =maxY + patrolPoint.position.y; // Inicializamos el valor relativo de maxY

        patrolPoint.position = new Vector2(Random.Range(relativelMinX, relativeMaxX), Random.Range(relativeMinY, relativeMaxY)); // Asignamos el punto siguiente al que nos vamos a desplazar
        timer = waitTime; // Inicializamos el contador al tiempo de espera deseado
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, patrolPoint.position, movemetSpeed * Time.deltaTime); // Nos movemos al punto indicado

        if (Vector2.Distance(transform.position, patrolPoint.position) < 0.2f) // Nos fijamos si ya estamos cerca del punto indicado (randomPoint)
        {
            if (timer <= 0) // Comprobamos si ya paso el tiempo de espera deseado
            {
                patrolPoint.position = new Vector2(Random.Range(relativelMinX, relativeMaxX), Random.Range(relativeMinY, relativeMaxY)); // Asignamos el punto siguiente al que nos vamos a desplazar

                while (Vector2.Distance(transform.position, patrolPoint.position) < minDistance) // Nos fijamos si la distancia del nuevo punto supera la Distancia Minima
                {
                    patrolPoint.position = new Vector2(Random.Range(relativelMinX, relativeMaxX), Random.Range(relativeMinY, relativeMaxY)); // Asignamos el punto siguiente al que nos vamos a desplazar
                }

                timer = waitTime; // Reiniciamos el Contador
            }
            else
            {
                timer -= Time.deltaTime; // Si el tiempo no paso, vamos restando Time.deltaTime
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (patrolPoint != null) Gizmos.DrawWireCube(positionSquere, new Vector3(widthSquere, heightSquere, 0)); // Dibujamos un Gizmo para representar el Area donde va a patrullar
    }
}
