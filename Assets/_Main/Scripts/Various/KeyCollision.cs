using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class KeyCollision : MonoBehaviour
    {
        [SerializeField] private RawImage keyIcon = null;
        [SerializeField] private DoorScript door = null;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                door.hasKey = true;
                //keyIcon.gameObject.SetActive(true);
                keyIcon.color = new Color(0, 0, 0, 255);

                Debug.Log("now you have a key");

                gameObject.SetActive(false);

                SoundManager.PlaySound("KeyPickUp");
            }
            else
            {
                keyIcon.color = new Color(255, 255, 255, 50);
            }
        }
    }
}
