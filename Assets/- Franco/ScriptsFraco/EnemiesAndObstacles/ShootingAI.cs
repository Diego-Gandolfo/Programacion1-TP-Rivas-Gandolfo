﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    private float timeBetweenShots;
    public float starTimeBetweentShots;

    public Transform firePoint;
    public Transform player;
    public GameObject projectile;

    public Animator animator;
    void Start()
    {
        timeBetweenShots = starTimeBetweentShots;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            timeBetweenShots = starTimeBetweentShots;
            
            animator.SetTrigger("Attack");
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
