﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BossTornadoController : MonoBehaviour
    {
        [Header("Boss Settings")]
        [SerializeField] private Vector2 bossSize = new Vector2(0, 0);

        [Header("Fase 1")]
        [SerializeField] private float movemetSpeed1 = 0f;
        [SerializeField] private float minAttackTime1 = 0f;
        [SerializeField] private float maxAttackTime1 = 0f;
        [SerializeField] private Transform[] movePoints = null;
        private int nextPoint = 0;

        [Header ("Fase 2")]
        [SerializeField] private float movemetSpeed2 = 0f;
        [SerializeField] private float minAttackTime2 = 0f;
        [SerializeField] private float maxAttackTime2 = 0f;
        [SerializeField] private Transform moveCenter = null;
        [SerializeField] private Vector2 areaSize = new Vector2(0, 0);
        [SerializeField] private float minDistance = 0;
        private GameObject movePosition = null;
        private float minX = 0;
        private float maxX = 0;
        private float minY = 0;
        private float maxY = 0;

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
            // TODO: Boss Animator Idle

            stage = 0;
            timer = 0f;
            canAttack = false;
            canCount = false;

            maxHealth = enemyHealth.GetMaxHealth();

            nextPoint = Random.Range(0, movePoints.Length);

            movePosition = new GameObject("Patrol Position");
            movePosition.SetActive(false);

            minX = (areaSize.x / -2) + moveCenter.position.x;
            maxX = (areaSize.x / 2) + moveCenter.position.x;
            minY = (areaSize.y / -2) + moveCenter.position.y;
            maxY = (areaSize.y / 2) + moveCenter.position.y;

            movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        }

        private void Update()
        {
            currentHealth = enemyHealth.GetCurrentHealth();

            if (stage == 0)
            {
                if (detectTargetArea.DetectTargets()) StartStage(1);
            }
            else
            {
                if (canAttack)
                {
                    if (attackType == 1)
                    {
                        if (stage == 1)
                        {
                            print("InstantiateAttack 1");

                            // Animacion InstatiateAttack en Stage 1

                            canAttack = false;

                            StartAttack();
                        }
                        else
                        {
                            print("InstantiateAttack 2");

                            // Animacion InstatiateAttack en Stage 2

                            canAttack = false;

                            StartAttack();
                        }
                    }
                    else
                    { 
                        if (stage == 1)
                        {
                            //print("MoveAttack 1");

                            // Animacion MoveAttack en Stage 1

                            transform.position = Vector2.MoveTowards(transform.position, movePoints[nextPoint].position, movemetSpeed1 * Time.deltaTime);

                            if (Vector2.Distance(transform.position, movePoints[nextPoint].position) < 0.2f)
                            {
                                canAttack = false;

                                int currentPoint = nextPoint;

                                if (movePoints.Length != 0)
                                {
                                    while (currentPoint == nextPoint)
                                    {
                                        nextPoint = Random.Range(0, movePoints.Length);
                                    }
                                }

                                StartAttack();
                            }
                        }
                        else
                        {
                            //print("MoveAttack 2");

                            // Animacion MoveAttack en Stage 2

                            transform.position = Vector2.MoveTowards(transform.position, movePosition.transform.position, movemetSpeed2 * Time.deltaTime); // Nos movemos al punto indicado

                            if (Vector2.Distance(transform.position, movePosition.transform.position) < 0.2f) // Nos fijamos si ya estamos cerca del punto indicado (randomPoint)
                            {
                                canAttack = false;

                                movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // Asignamos el punto siguiente al que nos vamos a desplazar

                                while (Vector2.Distance(transform.position, movePosition.transform.position) < minDistance) // Nos fijamos si la distancia del nuevo punto supera la Distancia Minima
                                {
                                    movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // Asignamos el punto siguiente al que nos vamos a desplazar
                                }

                                StartAttack();
                            }
                        }
                    }
                }

                if (stage == 1)
                {
                    if (currentHealth <= (maxHealth / 2)) StartStage(2);
                }

                Timer();
            }

            if (currentHealth <= 0) Die();
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

        private void Die()
        {
            gameObject.SetActive(false);
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

        private void OnDrawGizmosSelected()
        {
            if (moveCenter != null) Gizmos.DrawWireCube(moveCenter.position, new Vector3(areaSize.x + bossSize.x, areaSize.y + bossSize.y, 0));
        }

    }
}
