using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class TrapTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject trap = null;
        private Animator animator;

        public CameraShake camShake;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            animator.SetBool("Enter", false);
            trap.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
               animator.SetBool("Enter", true);

               trap.gameObject.SetActive(true);
               CinemachineShake.Instance.ShakeCam(7f, .1f);

               SoundManager.PlaySound("MetalTrap");
            }
            else
            {
                animator.SetBool("Enter", false);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                animator.SetBool("Enter", false);
                trap.gameObject.SetActive(false);
            }
        }
    }
}
