using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Attack01 : MonoBehaviour
{
    [Header("Attack Area")]
    public Transform attackPosition;
    public LayerMask targetLayerMask;
    public float attackRange = 1.0f;

    [Header("Attack Settings")]
    public float damage = 10.0f;
    public float attackCooldown = 1.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack(); 
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, targetLayerMask);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPosition == null) return;

        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
