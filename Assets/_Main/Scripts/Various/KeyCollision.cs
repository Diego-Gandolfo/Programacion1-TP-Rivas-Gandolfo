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
                keyIcon.color = new Color(0, 0, 0, 255); // Ahora en lugar de Activarse, cambia el color

                Debug.Log("now you have a key");

                gameObject.SetActive(false);

                SoundManager.PlaySound("KeyPickUp");
            }
        }
    }
}
