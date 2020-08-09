using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement_vDiego : MonoBehaviour
{
    public float speed;

    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += Vector3.up; // Si los IF solo tienen una línea de código no necesitan las {} y eso simplifica la lectura
        if (Input.GetKey(KeyCode.S)) direction -= Vector3.up;
        if (Input.GetKey(KeyCode.A)) direction -= Vector3.right;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;

        transform.position += direction * speed * Time.deltaTime; // PARA QUE NO SE COMPENSEN LAS VELOCIDADES CUANDO TOCAS POR EJEMPLO A Y W

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // En lugar de tener una Variable mainCamera se puede usar directamente Camera.main
        Vector3 difference = mousePosition - this.transform.position;                

        float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
/*
 * ¿Cual es la ventaja de no tener una Variable mainCamera?
 * Si siempre vas a usar la MainCamera, no tiene sentido ponerlo en una Variable porque tenemos un comándo que nos dirije directamente a ella.
 * Por otro lado, tampoco tiene sentido que sea una Variable Pública. Las Variables Públicas solo tienen que ser para cosas que tengamos
 * que retocar/balancear o que tengamos que modificar durante la ejecución del juego.
 * 
 * Si la tenes como una Variable Pública es una cosa mas que tenes que arrastrar manualmente cada vez que usas el código.
*/
