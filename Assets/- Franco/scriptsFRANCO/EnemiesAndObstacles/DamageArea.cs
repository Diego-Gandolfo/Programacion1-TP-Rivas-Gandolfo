using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private int damage = 2;   
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TopDownCharacterMovement_vDiego TopDownCharacter = collision.transform.GetComponent<TopDownCharacterMovement_vDiego>();
        if (TopDownCharacter != null)
        {
            TopDownCharacter.TakeEnemyDamage(damage);
            Debug.Log("im taking damage");
        }
            
    }
}
