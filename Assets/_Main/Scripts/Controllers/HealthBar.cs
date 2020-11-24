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
            if (brokenHeartIcon != null) brokenHeartIcon.gameObject.SetActive(false);            
        }

        public void SetMaxHealth(float health)
        {
            if (slider != null)
            {
                slider.maxValue = health;
                slider.value = health;

                fill.color = gradient.Evaluate(1f);
            }
            else
            {
                fill.fillAmount = health;
            }
        }

        public void SetHealth(float health)
        {
            if (slider != null)
            {
                slider.value = health;
                //if (transform.parent.transform.parent.name == "Character") print($"Slider value = {slider.value}");
                fill.color = gradient.Evaluate(slider.normalizedValue);
            }
            else
            {
                fill.fillAmount = health;
            }
        }
    }
}
