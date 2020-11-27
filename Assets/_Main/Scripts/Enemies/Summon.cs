﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (currentTimeToSummon >= timeToSummon && canInstantiate)
            {
                Instantiate(enemy, summonPoint.position, Quaternion.identity);

                enemiesAmount++;

                animator.SetTrigger("IsInvoking");

                currentTimeToSummon = 0.0f;   
            }

            else if (!canInstantiate)
            {
                enemiesAmount = 0;

                currentTimeToResume += Time.deltaTime;

                if (currentTimeToSummon >= timeToResume)
                    canInstantiate = true; 
            }
        }

        else if (Vector2.Distance(transform.position, player.transform.position) >= maxDistance)
            enemiesAmount = 0;

        if (enemiesAmount >= 3)
        {
            canInstantiate = false;
            enemiesAmount = 0;
        }    
    }
}
