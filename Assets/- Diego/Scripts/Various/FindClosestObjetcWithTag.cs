/*
 * Este Script lo que hace es Buscar el Objeto más cercano con un determinado Tag.
 * 
 * Lo hará cada vez que el Objeto se active.
 * 
 * Si es necesario repetir la búsqueda sin desactivar el Objeto se puede usar FindClosestEnemy().
*/

using UnityEngine;
using System.Collections;

public class FindClosestObjetcWithTag : MonoBehaviour
{
    public string targetTag; // Variable para asignar el Tag que usaremos para encontrar el Objeto más cercano
    public GameObject closestObject; // Variable donde guardaremos el Objeto más cercano

    private void OnEnable()
    {
        closestObject = FindClosestEnemy(); // Al activarse el Objeto realizamos una búsqueda
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) closestObject = FindClosestEnemy(); // Si apretamos "L" se hace una nueva búsqueda
    }

    public GameObject FindClosestEnemy() // Funcion para realizar la búsqueda, es GameObject en lugar de void porque al terminar devolverá un GameObject
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag); // Array (vector o "lista") de GameObjects donde almacenamos todos los Objetos con el Tag designado
        GameObject closest = null; // Variable donde guardaremos el Objeto más cercano, la inicializamos en null por si no hubiese ningún Objeto con ese Tag en la Escena
        float closestDistance = Mathf.Infinity; // Variable donde iremos guardando la distancia más corta encontrada hasta el momento, la inicializamos en Infinito Positivo para que no haya ningún valor que vaya a ser mayor

        foreach (GameObject currentObject in objects) // Esto es un bucle (como un for o un while) que lo que hace es para cada Objeto dentro de la Lista de Objetos hacer lo que está adentro
        {
            Vector3 difference = currentObject.transform.position - transform.position; // Variable donde almacenamos la diferencia que hay con el Objeto Actual que estamos analizando
            float currentDistance = difference.sqrMagnitude; // Variable que almacena la Magnitud de la Diferencia al cuadrado... Por qué? No sé, así lo hacían en el Script que copié de internet... Por lo que estuve leyendo es más preciso hacerlo de esta manera que solo usando la diferencia entre los transform.position

            if (currentDistance < closestDistance) // Nos fijamos si la distancia con el Objeto Actual es menos a la del Objeto más cercano hasta ahora encontrado, la 1ra vez siempre ha a ser verdadero porque lo comparamos con Infinito Positivo
            {
                closest = currentObject; // Asignamos el Objeto Actual como el Objeto más cercano
                closestDistance = currentDistance; // Asignamos la Distancia Actual como la Distancia más cernana
            }
        }
        return closest; // Cuando terminó de mirar todos los Objetos y compararlos, nos devuelve el Objeto más cercano
    }
}
