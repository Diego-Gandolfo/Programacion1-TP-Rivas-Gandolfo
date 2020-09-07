using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour
{
    public Text text;
    public Animator animator;
    private void Update()
    {
        if (Input.anyKey)
        {
            text.gameObject.SetActive(false);
            animator.SetTrigger("KeyPressed");
        }
    }
}
