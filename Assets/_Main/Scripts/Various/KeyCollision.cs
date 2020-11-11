using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class KeyCollision : MonoBehaviour
    {
        [SerializeField] private GameObject keyIcon = null;
        [SerializeField] private DoorScript door = null;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                door.hasKey = true;
                keyIcon.gameObject.SetActive(true);

                Debug.Log("now you have a key");

                gameObject.SetActive(false);

                SoundManager.PlaySound("KeyPickUp");
            }
            else
            {
                keyIcon.gameObject.SetActive(false);
            }
        }
    }
}
