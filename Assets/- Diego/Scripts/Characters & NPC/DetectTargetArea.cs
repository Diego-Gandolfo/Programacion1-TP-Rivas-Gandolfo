using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class DetectTargetArea : MonoBehaviour
    {
        [SerializeField] private Transform detectionCenterPoint = null;
        [SerializeField] private float detectionRange = 1.0f;
        [SerializeField] private LayerMask targetsLayerMask = 0;

        private void Update()
        {
            bool check = DetectTargets();

            if (check)
            {
                Debug.Log("Encontre algo! check >> " + check);
            }
            else
            {
                Debug.Log("check >> " + check);
            }
        }

        private bool DetectTargets()
        {
            Collider2D[] targetsDetected = Physics2D.OverlapCircleAll(detectionCenterPoint.position, detectionRange, targetsLayerMask); 

            if (targetsDetected.Length > 0) return (true);
            else return (false);
        }

        private void OnDrawGizmosSelected()
        {
            if (detectionCenterPoint != null) Gizmos.DrawWireSphere(detectionCenterPoint.position, detectionRange); // Esto es para dibujar donde está el Overlap
        }

    }
}
