using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int damage = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemy = collision.transform.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakePlayerDamage(damage);
            Debug.Log("PlayerIsAttacking");
        }

    }
}
