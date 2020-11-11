using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class DoorScript : MonoBehaviour
    {
        public bool hasKey;

        private Animator animator;

        private Collider2D doorCol;

        [SerializeField] private GameObject keyIcon = null;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            doorCol = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !hasKey)
            {
                animator.SetBool("CanOpen", false);

                SoundManager.PlaySound("IronGateClosed");

                Debug.Log("you need a key");
            }
            else if (collision.gameObject.CompareTag("Player") && hasKey)
            {
                animator.SetBool("CanOpen", true);
                keyIcon.gameObject.SetActive(false);

                Debug.Log("you can pass now");

                SoundManager.PlaySound("IronGate");

                doorCol.enabled = false;
            }
        }

    }


}
