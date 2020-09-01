using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public Gradient gradient;
        public Image fill;

        public RawImage brokenHeartIcon;

        public Animator animator;
        
        private void Start()
        {
            brokenHeartIcon.gameObject.SetActive(false);
        }

        public void SetMaxHealth(float health)
        {

            slider.maxValue = health;
            slider.value = health;

            fill.color = gradient.Evaluate(1f);
        }
        public void SetHealth(float health)
        {
            slider.value = health;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
