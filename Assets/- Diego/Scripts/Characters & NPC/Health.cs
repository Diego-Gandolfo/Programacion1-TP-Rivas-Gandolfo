/*
 * Script para asignar un valor de Vida a un Objeto
 * 
 * Si tiene Vida, puede recibir daño
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100; // Asignamos la Vida Máxima, [SerializeField] se usa para mostrar en el Inspector una variable privada
        [SerializeField] private float currentHealth; // Iremos almacenando la Vida Actual

        private void Start()
        {
            currentHealth = maxHealth; // Inicializamos la Vida Actual igual a Vida Máxima
        }

        public void TakeDamage(float damage) // Función para aplicar Daño, recibe un float y no devuelve nada
        {
            currentHealth -= damage; // Actualizamos la Vida Actual, restandole el Daño
            if (currentHealth <= 0) Die(); // Si la Vida Actual es igual o menor a 0, llamamos la Función de Muerte
        }

        private void Die()
        {
            Destroy(gameObject); // Destruimos el Objeto
        }
    }
}
