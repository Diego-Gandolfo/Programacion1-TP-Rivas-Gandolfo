/*
 * Script para realizar un Ataque Cuerpo a Cuerpo
 * 
 * Buscará en un área los Objetivos que tengan el LayerMask indicado y le aplicará un daño
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class CharacterAttackMelee : MonoBehaviour
    {
        [Header("Attack Area")] // Esto es simplemente un Título para el Inspector
        [SerializeField] private Transform attackPosition = null; // Determinamos donde se ubicara el Centro del Golpe
        [SerializeField] private float attackRange = 1.0f; // Determinamos el Rango del Golpe

        [Header("Attack Settings")] // Esto es simplemente un Título para el Inspector
        [SerializeField] private LayerMask targetsLayerMask = 0; // Determinamos las LayerMask que pueden ser golpeadas por este Ataque
        [SerializeField] private float damage = 10.0f; // Determinamos el Daño que se aplicará a los Objetivos alcanzados
        [SerializeField] private float attackCooldown = 1.0f; // El tiempo que deberá transcurrir para volver a hacer el Ataque
        private float cooldownTimer = 0.0f; // Variable que usaremos para verificar si ya paso el tiempo de Enfriamiento del Ataque

        private void Update()
        {
            if ((Input.GetMouseButtonDown(0)) && (Time.time >= cooldownTimer)) // Si hace Click Izquierdo y pasó el tiempo de Enfriamiento
            {
                Attack(); // Realizamos el Ataque
                cooldownTimer = Time.time + attackCooldown; // Sumamos el Tiempo de Enfriamiento y tiempo que lleva la aplicación ejecutandose (Time.time)
            }
        }

        private void Attack()
        {
            Collider2D[] targetsHit = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, targetsLayerMask); // Creamos un Array (vector o "lista") de Objetivos Golpeados, para esto creamos un Overlap que es como una especie de Collider

            foreach (Collider2D target in targetsHit) // Esto es un bucle (como un for) que se fija cada Objetivo dentro de los Objetivos Alcanzados
            {
                if (target.GetComponent<EnemyHealth>() != null) // Nos fijamos si el Objetivo tiene componente Vida
                {
                    target.GetComponent<EnemyHealth>().TakePlayerDamage(damage); // Aplicamos el daño
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPosition != null) Gizmos.DrawWireSphere(attackPosition.position, attackRange); // Esto es para dibujar donde está el Overlap
        }
    }
}
