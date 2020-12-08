﻿using OnceUponAMemory.Diego;
using OnceUponAMemory.Franco;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class CutsceneTrigger : MonoBehaviour
    {
        public static bool isCutsceneOn;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private Animator doorLightAnimator;

        [SerializeField]
        private GameObject doorLight;

        [SerializeField]
        private Animator deactivatedTrapAnimator;

        [SerializeField]
        private GameObject sound;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                sound.gameObject.SetActive(true);

                //SoundManager.PlaySound("HeavyChain");

                doorLight.SetActive(true);

                isCutsceneOn = true;

                animator.SetBool("Cutscene", true);

                deactivatedTrapAnimator.SetBool("Open", true);

                Invoke(nameof(StopCutscene), 3f);
            }
            else
                sound.gameObject.SetActive(false);
        }

        void StopCutscene()
        {
            gameObject.SetActive(false);
            doorLight.SetActive(false);

            isCutsceneOn = false;

            animator.SetBool("Cutscene", false);

            deactivatedTrapAnimator.SetBool("Open", false);
        }
    }
}
