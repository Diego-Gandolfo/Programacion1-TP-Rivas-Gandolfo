using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace OnceUponAMemory.Main
{
    public class BossTornadoController : MonoBehaviour
    {
        [Header("General Settings")]
        [SerializeField] private Vector2 bossSize = new Vector2(0, 0);
        [SerializeField] private float animationDieDuration = 0f;

        [Header("Fase 1")]
        [SerializeField] private float minAttackTime1 = 0f;
        [SerializeField] private float maxAttackTime1 = 0f;

        [Header("Fase 1 - MoveAttack")]
        [SerializeField] private DamageArea damageArea1 = null;
        [SerializeField] private float movemetSpeed1 = 0f;
        [SerializeField] private Transform[] movePoints = null;
        private int nextPoint = 0;
        [SerializeField] private float animationMoveDuration1 = 0f;

        [Header("Fase 1 - InstantiateAttack")]
        [SerializeField] private MiniTornadoController miniTornadoPrefab1 = null;
        [SerializeField] private float miniTornadoImpulse1 = 0f;
        [SerializeField] private Transform[] miniTornadoSpawnpoints1 = null;
        [SerializeField] private float animationInstantiateDuration1 = 0f;

        [Header("Fase 2")]
        [SerializeField] private float animationConvertionDuration = 0f;
        [SerializeField] private float minAttackTime2 = 0f;
        [SerializeField] private float maxAttackTime2 = 0f;

        [Header ("Fase 2 - MoveAttack")]
        [SerializeField] private DamageArea damageArea2 = null;
        [SerializeField] private float movemetSpeed2 = 0f;
        [SerializeField] private Transform moveCenter = null;
        [SerializeField] private Vector2 areaSize = new Vector2(0, 0);
        [SerializeField] private float minDistance = 0;
        private GameObject movePosition = null;
        private float minX = 0;
        private float maxX = 0;
        private float minY = 0;
        private float maxY = 0;
        [SerializeField] private float animationMoveDuration2 = 0f;

        [Header ("Fase 2 - InstantiateAttack")]
        [SerializeField] private MiniTornadoController miniTornadoPrefab2 = null;
        [SerializeField] private float miniTornadoImpulse2 = 0f;
        [SerializeField] private Transform[] miniTornadoSpawnpoints2 = null;
        [SerializeField] private float animationInstantiateDuration2 = 0f;

        // Componentes
        private EnemyHealth enemyHealth = null;
        private DetectTargetArea detectTargetArea = null;
        private Animator animator = null;

        // Privadas Varias
        private int stage = 0;
        private int attackType = 0;
        private bool canAttack = false;
        private bool finishAnimation = false;
        private bool canCountAttack = false;
        private float attackTime = 0f;
        private float timerAttack = 0f;
        private float timerAnimation = 0f;
        private float currentHealth = 0f;
        private float maxHealth = 0f;
        private bool doingMoveAttack = false;
        private bool isDying = false;
        private bool isConverting = false;

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
            timerAttack = 0f;
            canAttack = false;
            canCountAttack = false;

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
            
            if (stage != 0)
            {
                if (canAttack)
                {
                    if (attackType == 1)
                    {
                        if (stage == 1)
                        {
                            if (timerAnimation == 0)
                            {
                                finishAnimation = false;
                                animator.SetTrigger("Instantiate1");
                            }
                            
                            TimerAnimation(animationInstantiateDuration1);
                            
                            if (finishAnimation)
                            {
                                timerAnimation = 0f;
                                InstantiateAttack();
                            }
                        }
                        else
                        {
                            if (timerAnimation == 0)
                            {
                                finishAnimation = false;
                                animator.SetTrigger("Instantiate2");
                            }

                            TimerAnimation(animationInstantiateDuration2);

                            if (finishAnimation)
                            {
                                timerAnimation = 0f;
                                InstantiateAttack();
                            }
                        }
                    }
                    else
                    { 
                        if (stage == 1)
                        {
                            if (timerAnimation == 0 && !doingMoveAttack)
                            {
                                finishAnimation = false;
                                animator.SetTrigger("Anticipation1");
                                animator.SetBool("IsMoving1", true);
                            }

                            if (finishAnimation)
                            {
                                doingMoveAttack = true;
                                timerAnimation = 0f;
                                MoveAttack();
                            }
                            else
                            {
                                TimerAnimation(animationMoveDuration1);
                            }
                        }
                        else
                        {
                            if (timerAnimation == 0 && !doingMoveAttack)
                            {
                                finishAnimation = false;
                                animator.SetTrigger("Anticipation2");
                                animator.SetBool("IsMoving2", true);
                            }

                            if (finishAnimation)
                            {
                                doingMoveAttack = true;
                                timerAnimation = 0f;
                                MoveAttack();
                            }
                            else
                            {
                                TimerAnimation(animationMoveDuration2);
                            }
                        }
                    }
                }

                if (stage == 1 && !doingMoveAttack && finishAnimation)
                {
                    if (currentHealth <= (maxHealth / 2)) StartStage(2);
                }

                TimerAttack();
            }

            if (currentHealth <= 0 && !isDying)
            {
                timerAnimation = 0f;
                Die();
            }
        }

        private void StartStage(int value)
        {

            stage = value;

            print($"Boss Stage {value}");

            if (stage == 2)
            {
                damageArea1.gameObject.SetActive(false);
                doingMoveAttack = false;
                canAttack = false;

                if (timerAnimation == 0)
                {
                    finishAnimation = false;
                    animator.SetTrigger("Stage2");
                }

                TimerAnimation(animationConvertionDuration);

                if (finishAnimation)
                {
                    timerAnimation = 0f;
                    StartAttack();
                }
            }
            else
            {
                StartAttack();
            }
        }

        private void StartAttack()
        {
            //attackType = Random.Range(1, 3);

            attackType = attackType == 1 ? 2 : 1; // Para testear y que haga una vez cada uno, COMENTAR AL TERMINAR !!!
            //attackType = 2; // Para testear y que siempre el mismo, COMENTAR AL TERMINAR !!!

            attackTime = stage == 1 ? Random.Range(minAttackTime1, maxAttackTime1) : Random.Range(minAttackTime2, maxAttackTime2);

            canCountAttack = true;
        }

        private void InstantiateAttack()
        {
            canAttack = false;

            if (stage == 1)
            {
                for (int i = 0; i < miniTornadoSpawnpoints1.Length; i++)
                {
                    Vector3 position = miniTornadoSpawnpoints1[i].position;
                    MiniTornadoController miniTornadoClone = Instantiate(miniTornadoPrefab1, position, Quaternion.identity);
                    Vector2 direction = position - transform.position;
                    miniTornadoClone.ImpulseMiniTornado(direction.normalized, miniTornadoImpulse1);
                }
            }
            else
            {
                for (int i = 0; i < miniTornadoSpawnpoints2.Length; i++)
                {
                    Vector3 position = miniTornadoSpawnpoints2[i].position;
                    MiniTornadoController miniTornadoClone = Instantiate(miniTornadoPrefab2, position, Quaternion.identity);
                    Vector2 direction = position - transform.position;
                    miniTornadoClone.ImpulseMiniTornado(direction.normalized, miniTornadoImpulse2);
                }
            }

            StartAttack();
        }

        private void MoveAttack()
        {
            if (stage == 1)
            {
                damageArea1.gameObject.SetActive(true);

                transform.position = Vector2.MoveTowards(transform.position, movePoints[nextPoint].position, movemetSpeed1 * Time.deltaTime);

                if (Vector2.Distance(transform.position, movePoints[nextPoint].position) < 0.2f)
                {
                    damageArea1.gameObject.SetActive(false);

                    canAttack = false;

                    int currentPoint = nextPoint;

                    if (movePoints.Length != 0)
                    {
                        while (currentPoint == nextPoint)
                        {
                            nextPoint = Random.Range(0, movePoints.Length);
                        }
                    }
                    
                    doingMoveAttack = false;
                    animator.SetBool("IsMoving1", false);

                    StartAttack();
                }
            }
            else
            {
                damageArea2.gameObject.SetActive(true);

                transform.position = Vector2.MoveTowards(transform.position, movePosition.transform.position, movemetSpeed2 * Time.deltaTime);

                if (Vector2.Distance(transform.position, movePosition.transform.position) < 0.2f)
                {
                    damageArea2.gameObject.SetActive(false);

                    canAttack = false;

                    movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

                    while (Vector2.Distance(transform.position, movePosition.transform.position) < minDistance)
                    {
                        movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    }

                    doingMoveAttack = false;
                    animator.SetBool("IsMoving2", false);

                    StartAttack();
                }
            }
        }

        private void Die()
        {
            isDying = true;
            canAttack = false;
            damageArea2.gameObject.SetActive(false);

            if (timerAnimation == 0)
            {
                finishAnimation = false;
                animator.SetTrigger("IsDead");
            }

            TimerAnimation(animationDieDuration);

            if (finishAnimation)
            {
                timerAnimation = 0f;
                gameObject.SetActive(false);
            }
        }

        private void TimerAttack()
        {
            if (canCountAttack && timerAttack >= attackTime)
            {
                canCountAttack = false;
                timerAttack = 0f;
                canAttack = true;
            }
            else if (canCountAttack && timerAttack < attackTime)
            {
                timerAttack += Time.deltaTime;
            }
        }

        private void TimerAnimation(float duration)
        {
            if (timerAnimation >= duration)
            {
                finishAnimation = true;
            }
            else if (timerAnimation < duration)
            {
                timerAnimation += Time.deltaTime;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (moveCenter != null) Gizmos.DrawWireCube(moveCenter.position, new Vector3(areaSize.x + bossSize.x, areaSize.y + bossSize.y, 0));
        }
    }
}
