using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyPatrolPointsAI : MonoBehaviour
    {
        private PatrolPoints patrolPoints = null; // Componente de Patrullaje
        private FollowEnemy followEnemy = null; // Componente de Persecusión
        private DetectTargetArea detectTargetArea = null; // Componente de Detección
        [SerializeField] private bool keepFollowing = false; // Si debe seguir persiguiendo al Objetivo una vez que se va del Area de Detección o si debe de volver al Patrullaje

        private void Start()
        {
            patrolPoints = GetComponent<PatrolPoints>(); // Detección del Componente PatrolPoints
            if (patrolPoints == null) Debug.LogError("A " + gameObject.name + " le falta el Componente PatrolPoints y el EnemyPatrolPointsAI no funcionara correctamente");
            followEnemy = GetComponent<FollowEnemy>(); // Detección del Componente FollowEnemy
            if (patrolPoints == null) Debug.LogError("A " + gameObject.name + " le falta el Componente FollowEnemy y el EnemyPatrolPointsAI no funcionara correctamente");
            detectTargetArea = GetComponent<DetectTargetArea>(); // Detección del Componente DetectTargetArea
            if (patrolPoints == null) Debug.LogError("A " + gameObject.name + " le falta el Componente DetectTargetArea y el EnemyPatrolPointsAI no funcionara correctamente");

            patrolPoints.enabled = true; // Inicializamos patrolPoints en TRUE para que arranque Patrullando
            followEnemy.enabled = false; // Inicializamos followEnemy en FALSE porque empieza Patrullando
        }

        private void Update()
        {
            bool check = detectTargetArea.DetectTargets();

            if (check) // Si detecto un Objetivo
            {
                patrolPoints.enabled = false; // Deja de Patrullar
                followEnemy.enabled = true; // Empieza a Perseguir
            }
            else if (!check && !keepFollowing) // Si ya no detecta enemigos en su campo y no debe seguir persiguiendo
            {
                followEnemy.enabled = false; // Deja de Perseguir
                patrolPoints.enabled = true; // Vuelve a Patrullar
            }
        }
    }
}
