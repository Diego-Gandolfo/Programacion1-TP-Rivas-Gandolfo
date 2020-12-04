using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BossTornadoController : MonoBehaviour
    {
        [Header ("Fase 1")]
        [SerializeField] private float minAttackTime1 = 0f;
        [SerializeField] private float maxAttackTime1 = 0f;

        [Header ("Fase 2")]
        [SerializeField] private float minAttackTime2 = 0f;
        [SerializeField] private float maxAttackTime2 = 0f;

        private EnemyHealth enemyHealth = null;
        private DetectTargetArea detectTargetArea = null;
        private Animator animator = null;

        private int stage = 0;
        private int attackType = 0;
        private bool canAttack = false;
        private bool canCount = false;
        private float attackTime = 0f;
        private float timer = 0f;
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
            maxHealth = enemyHealth.GetMaxHealth();
            // TODO: Boss Animator Idle
        }

        private void Update()
        {
            if (stage == 0)
            {
                if (detectTargetArea.DetectTargets()) StartStage(1);
            }
            else
            {
                if (canAttack) DoAttack();

                if (stage == 1)
                {
                    currentHealth = enemyHealth.GetCurrentHealth();

                    if (currentHealth <= (maxHealth / 2)) StartStage(2);
                }

                Timer();
            }
        }

        private void StartStage(int value)
        {
            stage = value;
            print($"Boss Stage {value}");
            StartAttack();
        }

        private void StartAttack()
        {
            // TODO: Boss Animator Idle

            attackType = Random.Range(1, 3);

            attackTime = stage == 1 ? Random.Range(minAttackTime1, maxAttackTime1) : Random.Range(minAttackTime2, maxAttackTime2);

            canCount = true;
        }

        private void DoAttack()
        {
            canAttack = false;
            
            if (attackType == 1) InstantiateAttack();
            else MoveAttack();
        }

        private void InstantiateAttack()
        {
            print("InstantiateAttack");
            // TODO: InstantiateAttack
            // TODO: Boss Animator InstantiateAttack
            StartAttack();
        }

        private void MoveAttack()
        {
            print("MoveAttack");
            // TODO: MoveAttack
            // TODO: Boss Animator MoveAttack
            StartAttack();
        }

        private void Timer()
        {
            if (canCount && timer >= attackTime)
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
    }
}
