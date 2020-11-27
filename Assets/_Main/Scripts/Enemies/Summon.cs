using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField]
    private float timeToSummon = 1.0f;

    [SerializeField]
    private float currentTimeToSummon = 0.0f;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private int enemiesAmount = 0;

    [SerializeField]
    private float timeToResume = 3.0f;

    private float currentTimeToResume = 0.0f;

    [SerializeField]
    private bool canInstantiate = false;

    [SerializeField]
    private Transform summonPoint;

    private Animator animator;

    [SerializeField] private Transform player;

    [SerializeField] private float maxDistance = 0;

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

        Debug.Log(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= maxDistance)
        {
            

            if (currentTimeToSummon >= timeToSummon && canInstantiate)
            {
                Instantiate(enemy, summonPoint.position, Quaternion.identity);

                animator.SetTrigger("IsInvoking");

                currentTimeToSummon = 0.0f;

                enemiesAmount++;

                if (enemiesAmount >= 3)
                    canInstantiate = false;
            }

            else if (!canInstantiate)
            {
                currentTimeToResume += Time.deltaTime;

                if (currentTimeToSummon >= timeToResume)
                {
                    canInstantiate = true;
                    enemiesAmount = 0;
                }
            }
        }
    }
}
