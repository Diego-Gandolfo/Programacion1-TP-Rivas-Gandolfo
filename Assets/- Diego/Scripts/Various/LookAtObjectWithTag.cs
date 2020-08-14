/*
 * Este Script lo que hace es que el Objeto al que se lo asigna mire a donde está el Objeto con un determinado Tag
 * 
 * Funciona para Objetos 2D
 * 
 * Si hay varios Objetos con el mismo Tag podría no funcionar correctamente
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObjectWithTag : MonoBehaviour
{
    public string tagObject; // Asignamos el Tag del Objeto a mirar
    private GameObject objectWithTag; // Alacenaremos el Objeto con el Tag a mirar

    private void Start()
    {
        objectWithTag = GameObject.FindGameObjectWithTag(tagObject); // Buscamos el Objeto que tiene el Tag elegido
    }

    private void Update()
    {
        Vector2 direction = new Vector2(objectWithTag.transform.position.x - transform.position.x, objectWithTag.transform.position.y - transform.position.y); // Calculamos la dirección a la que hay que mirar

        transform.up = direction; // Actualizamos el Transform para que mire al Objeto con el Tag elegido
    }
}
