using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class TutorialTextController : MonoBehaviour
    {
        [SerializeField] private Text tutorialText;
        [SerializeField] private Animator animator;
        /*
        private void Update()
        {
            if (Input.anyKey)
            {
                tutorialText.gameObject.SetActive(false);
                animator.SetTrigger("KeyPressed");
            }
        }*/

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                animator.SetTrigger("KeyPressed");
                Destroy(gameObject, 5f);
            }
        }
    }

}
