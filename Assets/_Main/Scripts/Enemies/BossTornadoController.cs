using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BossTornadoController : MonoBehaviour
    {
        // Mientras no está el Player, está en Idle

        // Cuando detecta al Player, comienza la fase 1

        // Cuando tiene menos del 50% de la vida, comienza la fase 2

        [Header ("Settings")]
        [SerializeField] private PlayerHealth character = null;

        [Header("Fase 1")]


        private BossTornadoMove bossTornadoMove = null;
        private BossTornadoInstantiate bossTornadoInstantiate = null;

        private DetectTargetArea detectTargetArea = null;
        private Animator animator = null;
        private int state = 0;

        private void Awake()
        {
            // Chequeamos que esté asignado el PlayerHealth
            if (gameObject.GetComponent<PlayerHealth>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerHealth asignado");

            // Chequeamos que tenga DetectTargetArea
            if (gameObject.GetComponent<DetectTargetArea>() == null) Debug.LogError(gameObject.name + " no tiene componente DetectTargetArea");
            if (gameObject.GetComponent<DetectTargetArea>() != null) detectTargetArea = gameObject.GetComponent<DetectTargetArea>();

            // Chequeamos que tenga Animator
            if (gameObject.GetComponent<Animator>() == null) Debug.LogError(gameObject.name + " no tiene componente Animator");
            if (gameObject.GetComponent<Animator>() != null) animator = gameObject.GetComponent<Animator>();

            // Chequeamos que tenga BossTornadoMove
            if (gameObject.GetComponent<BossTornadoMove>() == null) Debug.LogError(gameObject.name + " no tiene componente BossTornadoMove");
            if (gameObject.GetComponent<BossTornadoMove>() != null) bossTornadoMove = gameObject.GetComponent<BossTornadoMove>();

            // Chequeamos que tenga BossTornadoInstantiate
            if (gameObject.GetComponent<BossTornadoInstantiate>() == null) Debug.LogError(gameObject.name + " no tiene componente BossTornadoInstantiate");
            if (gameObject.GetComponent<BossTornadoInstantiate>() != null) bossTornadoInstantiate = gameObject.GetComponent<BossTornadoInstantiate>();
        }

        private void Start()
        {
            state = 0;
            // TODO: Boss Animator Idle
        }

        private void Update()
        {
            if (state == 0 && detectTargetArea.DetectTargets())
            {
                state = 1;
            }
            else if (state == 1)
            {
                // Comportamiento de Fase 1
            }
            else if(state == 2)
            {
                // Comportamiento de Fase 2
            }
        }
    }
}
