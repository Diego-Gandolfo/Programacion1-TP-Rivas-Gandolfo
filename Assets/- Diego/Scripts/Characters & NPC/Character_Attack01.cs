using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Attack01 : MonoBehaviour
{
    [Header("Attack Area")]
    public Transform attackPosition;
    public LayerMask targetsLayerMask;
    public float attackRange = 1.0f;

    [Header("Attack Settings")]
    public float damage = 10.0f;
    public float attackCooldown = 1.0f;
    private float cooldownTimer = 0.0f;

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (Time.time >= cooldownTimer))
        {
            Attack();
            cooldownTimer = Time.time + attackCooldown;
        }
    }

    private void Attack()
    {
        Collider2D[] targetsHit = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, targetsLayerMask);

        foreach (Collider2D target in targetsHit)
        {
            if (target.GetComponent<Health>() != null)
            {
                Debug.Log("Hit " + target.name);
                target.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPosition != null) Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
