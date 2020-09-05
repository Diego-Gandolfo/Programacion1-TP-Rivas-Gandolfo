using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FragmentosScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerHealth TopDownCharacter = collision.GetComponent<PlayerHealth>();
            if (TopDownCharacter != null)
            {
                Debug.Log("Im Being Collected");
                FragmentosCounter.Amount += 1;
                
                SoundManager.PlaySound("PickUpItem");
                Destroy(gameObject);
            }
        }
    }
}
