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
        [SerializeField] private float minAttackTime1 = 0f;
        [SerializeField] private float maxAttackTime1 = 0f;
        [SerializeField] private float minAttackTime2 = 0f;
        [SerializeField] private float maxAttackTime2 = 0f;

        private EnemyHealth enemyHealth = null;
        private DetectTargetArea detectTargetArea = null;
        private Animator animator = null;
        private int stage = 0;
        private int attackType = 0;
        private float attackTime = 0f;
        private float timer = 0f;
        private bool canAttack = false;
        private bool canCount = false;
        private float currentHealth = 0f;
        private float maxHealth = 0f;

        private void Awake()
        {
            // Chequeamos que tenga DetectTargetArea
            if (gameObject.GetComponent<DetectTargetArea>() == null) Debug.LogError(gameObject.name + " no tiene componente DetectTargetArea");
            if (gameObject.GetComponent<DetectTargetArea>() != null) detectTargetArea = gameObject.GetComponent<DetectTargetArea>();

            // Chequeamos que tenga Animator
            if (gameObject.GetComponent<Animator>() == null) Debug.LogError(gameObject.name + " no tiene componente Animator");
            if (gameObject.GetComponent<Animator>() != null) animator = gameObject.GetComponent<Animator>();

            // Chequeamos que tenga EnemyHealth
            if (gameObject.GetComponent<EnemyHealth>() == null) Debug.LogError(gameObject.name + " no tiene componente EnemyHealth");
            if (gameObject.GetComponent<EnemyHealth>() != null) enemyHealth = gameObject.GetComponent<EnemyHealth>();
        }

        private void Start()
        {
            stage = 0;
            timer = 0f;
            canAttack = false;
            canCount = false;
            attackType = Random.Range(1, 3); // Para que sea 1 o 2 como resultado
            maxHealth = enemyHealth.GetMaxHealth();
            // TODO: Boss Animator Idle
        }

        private void Update()
        {
            if (stage == 0)
            {
                if (detectTargetArea.DetectTargets())
                {
                    attackTime = Random.Range(minAttackTime1, maxAttackTime1);
                    stage = 1;
                    print("Boss Stage 1");
                    canCount = true;
                }
            }
            else if (stage == 1)
            {
                if (canAttack)
                {
                    canAttack = false;
                    attackTime = Random.Range(minAttackTime1, maxAttackTime1);
                    if (attackType == 1) InstantiateAttack();
                    else MoveAttack();
                }

                currentHealth = enemyHealth.GetCurrentHealth();

                if (currentHealth < (maxHealth / 2))
                {
                    attackTime = Random.Range(minAttackTime2, maxAttackTime2);
                    stage = 2;
                    print("Boss Stage 2");
                }
            }
            else
            {
                if (canAttack)
                {
                    canAttack = false;
                    attackTime = Random.Range(minAttackTime2, maxAttackTime2);
                    if (attackType == 1) InstantiateAttack();
                    else MoveAttack();
                }
            }

            if (canCount &&  timer >= attackTime)
            {
                canCount = false;
                timer = 0f;
                canAttack = true;
            }
            else if (canCount && timer < attackTime)
            {
                timer += Time.deltaTime;
            }
        }

        private void InstantiateAttack()
        {
            print("InstantiateAttack");
            // Ataque que Instancia Mini Tornaditos
            // TODO: Boss Animator InstantiateAttack
            attackType = Random.Range(1, 3);
            canCount = true;
        }

        private void MoveAttack()
        {
            print("MoveAttack");
            // Ataque que se desplaza
            // TODO: Boss Animator MoveAttack
            attackType = Random.Range(1, 3);
            canCount = true;
        }
    }
}
