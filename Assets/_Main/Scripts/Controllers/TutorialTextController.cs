using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class TutorialTextController : MonoBehaviour
    {
        //[SerializeField] private Text tutorialText = null;
        private Animator animator;

        [SerializeField] private GameObject pointLight = null;

        /*
        private void Update()
        {
            if (Input.anyKey)
            {
                tutorialText.gameObject.SetActive(false);
                animator.SetTrigger("KeyPressed");
            }
        }*/
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                animator.SetTrigger("KeyPressed");
                pointLight.gameObject.SetActive(true);

                
                //Destroy(this.gameObject, 5f);
            }
        }
    }

}
