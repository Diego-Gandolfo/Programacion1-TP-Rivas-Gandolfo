using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Summon : MonoBehaviour
    {
        private bool canInstantiate = false;

        [Header("LightEnemy")]

        [SerializeField]
        private GameObject enemy;

        [SerializeField]
        private int enemiesAmount = 0;


        [Header("Time to Summon and time to resume")]

        [SerializeField]
        private float timeToResume = 3.0f;

        private float currentTimeToResume = 0.0f;

        [SerializeField]
        private float timeToSummon = 1.0f;

        [SerializeField]
        private float currentTimeToSummon = 0.0f;


        [Header("Components")]

        [SerializeField]
        private Transform summonPoint;

        private Animator animator;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private float maxDistance = 0;

        [SerializeField]
        private GameObject summonSound;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            canInstantiate = true;

            currentTimeToSummon = timeToSummon;
        }

        private void Update()
        {
            

            currentTimeToSummon += Time.deltaTime;

            if (Vector2.Distance(transform.position, player.transform.position) <= maxDistance)
            {
                summonSound.SetActive(true);

                if (currentTimeToSummon >= timeToSummon && canInstantiate)
                {
                    GameObject enemyClone = Instantiate(enemy, summonPoint.position, Quaternion.identity);
                    FollowEnemy followEnemy = enemyClone.GetComponent<FollowEnemy>();

                    if (followEnemy != null) followEnemy.player = player;
                    else Debug.LogError($"{enemyClone} no tiene FollowEnemy donde se busca");

                    enemiesAmount++;

                    

                    animator.SetTrigger("IsInvoking");

                    currentTimeToSummon = 0.0f;

                    
                }

                

                else if (!canInstantiate)
                {
                    

                    enemiesAmount = 0;

                    currentTimeToResume += Time.deltaTime;

                    if (currentTimeToSummon >= timeToResume)
                    {
                        canInstantiate = true;

                        summonSound.SetActive(false);
                    }
                        
                }
            }

            else if (Vector2.Distance(transform.position, player.transform.position) >= maxDistance)
                enemiesAmount = 0;

            if (enemiesAmount >= 3)
            {
                canInstantiate = false;
                enemiesAmount = 0;
            }

            else
            {
                
            }
        }

        
    }
}
