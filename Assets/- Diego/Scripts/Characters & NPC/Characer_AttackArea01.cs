using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characer_AttackArea01 : MonoBehaviour
{
    public List<Collider2D> collidersInAttackArea = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collidersInAttackArea.Contains(collision)) // Se fija si el Collider no está en la Lista.
        {
            collidersInAttackArea.Add(collision); // Si no lo está, lo agrega.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collidersInAttackArea.Contains(collision)) // Se fija si el Collider está en la Lista
        {
            collidersInAttackArea.Remove(collision); // Si está, lo saca.
        }
    }
}
