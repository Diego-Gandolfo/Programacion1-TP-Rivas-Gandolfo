using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OnceUponAMemory.Franco
{
    public class BoxScript : MonoBehaviour
    {
        public static event Action CreateDestroyed = delegate { };
        public Animator animator;
        public int ClickCountdown;
        // Start is called before the first frame update
        void Start()
        {
            ClickCountdown = 3;
        }

        // Update is called once per frame
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

