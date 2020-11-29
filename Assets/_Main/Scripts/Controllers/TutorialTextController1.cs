using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class TutorialTextController1 : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialText_Attack;

    [SerializeField]
    private Animator animator;

    private float timeToGo = 3f;
    private float currentTimeToGo = 0;

    private bool canCount;

    private void Start()
    {
        canCount = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutorialText_Attack.SetActive(true);
            canCount = true;
        }
        else
            canCount = false;
    }

    private void Update()
    {
        if(canCount == true)
        {
            currentTimeToGo += Time.deltaTime;

            if (currentTimeToGo >= timeToGo)
                animator.SetBool("Disappear", true);
        }
    }
}
*/
