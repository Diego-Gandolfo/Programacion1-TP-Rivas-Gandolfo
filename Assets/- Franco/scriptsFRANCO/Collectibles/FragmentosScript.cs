using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentosScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TopDownCharacterMovement_vDiego TopDownCharacter = collision.GetComponent<TopDownCharacterMovement_vDiego>();
        if (TopDownCharacter != null)
        {
            CounterScript.Amount += 1;
            Destroy(gameObject);
        }
            
    }
}
