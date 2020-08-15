﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPosition;
    public float attackRange = 1.0f;

    public LayerMask targetsLayerMask;
    public float damage = 1.0f;
    public float attackCooldown = 1.0f;
    private float cooldownTimer = 0.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= cooldownTimer)
        {
            PlayerIs();
            cooldownTimer = Time.time + attackCooldown;
        }
    }
    private void PlayerIs()
    {
        Collider2D[] targetshit = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, targetsLayerMask);

        foreach (Collider2D target in targetshit)
        {
            if (target.GetComponent<EnemyHealth>() != null)
            {
                target.GetComponent<EnemyHealth>().TakePlayerDamage(damage);
            }
        }


    }
}
