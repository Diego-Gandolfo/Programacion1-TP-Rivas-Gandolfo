using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Deactivator : MonoBehaviour
    {
        [SerializeField]
        private GameObject cutsceneTrigger;

        private float maxHealth = 0.5f;
        private float currentHealth;

        public bool hasBlockKey;

        private void Start()
        {
            hasBlockKey = false;

            currentHealth = maxHealth;
        }

        public void TakePlayerDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                hasBlockKey = true;
                gameObject.SetActive(false);

                cutsceneTrigger.gameObject.SetActive(true);
            }

            else
            {
                hasBlockKey = false;
                cutsceneTrigger.gameObject.SetActive(false);
            }
        }
    }
}
