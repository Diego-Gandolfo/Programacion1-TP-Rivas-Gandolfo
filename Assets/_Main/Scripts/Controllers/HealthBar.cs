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
            if (brokenHeartIcon != null) brokenHeartIcon.gameObject.SetActive(false); // Como todos usan el mismo Script me fijo antes de activar esto
        }

        public void SetMaxHealth(float health)
        {
            if (slider != null) // Si tiene slider es que tiene Barra de Vida
            {
                slider.maxValue = health;
                slider.value = health;

                fill.color = gradient.Evaluate(1f);
            }
            else // Sino es que es la Esfera de Vida del Player
            {
                fill.fillAmount = health;
            }
        }

        public void SetHealth(float health)
        {
            if (slider != null) // Si tiene slider es que tiene Barra de Vida
            {
                slider.value = health;
                //if (transform.parent.transform.parent.name == "Character") print($"Slider value = {slider.value}");
                fill.color = gradient.Evaluate(slider.normalizedValue);
            }
            else // Sino es que es la Esfera de Vida del Player
            {
                fill.fillAmount = health;
            }
        }
    }
}
