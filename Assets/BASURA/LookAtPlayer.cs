using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private float damage = 2f;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public Transform player;

    void Start()
    {
        timeBtwAttacks = startTimeBtwAttacks;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.LookAt(player);

        PlayerHealth TopDownCharacter = collision.transform.GetComponent<PlayerHealth>();
        if (timeBtwAttacks <= 0 && TopDownCharacter != null)
        {
            TopDownCharacter.TakeDamage(damage);
            Debug.Log("im taking reeeeal damage right here...");
            timeBtwAttacks = startTimeBtwAttacks;
        }

        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
    }
}
