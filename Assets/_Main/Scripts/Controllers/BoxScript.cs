using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OnceUponAMemory.Main
{
    public class BoxScript : MonoBehaviour
    {
        public static event Action CreateDestroyed = delegate { };
        public Animator animator;
        public int ClickCountdown;

        void Start()
        {
            ClickCountdown = 3;
        }

        void Update()
        {
            if (ClickCountdown < 1) CreateDestroyed(); 
        }

        private void OnMouseDown()
        {
            animator.SetTrigger("Clicked");
            ClickCountdown -= 1;
        }

    }
}

