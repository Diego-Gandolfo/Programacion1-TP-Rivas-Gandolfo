﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    private float timeBetweenShots;
    public float starTimeBetweentShots;

    public GameObject projectile;
    void Start()
    {
        timeBetweenShots = starTimeBetweentShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = starTimeBetweentShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
