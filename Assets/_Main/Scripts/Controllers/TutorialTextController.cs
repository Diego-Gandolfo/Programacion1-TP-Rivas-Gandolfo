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

        [SerializeField] 
        private GameObject pointLight = null;

        [SerializeField]
        private GameObject lifeBarCharacter;

        /*
        [SerializeField]
        private GameObject lifeBarSpider;
        */

        private bool canCount = false;
        private float timer = 0.0f;

        private float timeToGo = 3.0f;
        private float currentTimeToGo = 0.0f;

        [SerializeField]
        private GameObject secondTutorial;

        [SerializeField]
        private Animator secondAnimator;

        [SerializeField]
        private GameObject HUD;

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

        private void Start()
        {
            lifeBarCharacter.gameObject.SetActive(false);
            //lifeBarSpider.gameObject.SetActive(false);
            HUD.gameObject.SetActive(false);
        }

        private void Update()
        {
            currentTimeToGo += Time.deltaTime;

            if (currentTimeToGo >= timeToGo)
            {
                CutsceneTrigger.isCutsceneOn = false;

                if (!canCount && (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                {
                    secondAnimator.SetBool("KeyPressed", true);   

                    animator.SetTrigger("KeyPressed1");

                    pointLight.gameObject.SetActive(true);
                    lifeBarCharacter.gameObject.SetActive(true);
                    //lifeBarSpider.gameObject.SetActive(true);

                    HUD.gameObject.SetActive(true);

                    timer += Time.time + 1f;
                    canCount = true;
                }

                if (canCount && timer <= Time.time)
                {
                    Animator animator = lifeBarCharacter.GetComponent<Animator>();
                    animator.enabled = false;
                    this.gameObject.SetActive(false);
                }  
            }
            else
            {
                animator.SetBool("KeyPressed1", false);
                secondAnimator.SetBool("KeyPressed", false);

                CutsceneTrigger.isCutsceneOn = true;
            }
        }
    }
}
