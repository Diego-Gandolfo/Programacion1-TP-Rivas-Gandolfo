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

        [SerializeField]
        private Animator animator;

        private bool canCount = false;

        private float timeToDestroy = 1f;
        private float currentTimeToDestroy;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

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

                animator.SetTrigger("Broken");

                canCount = true;
            }

            else
            {
                hasBlockKey = false;
                cutsceneTrigger.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (canCount)
            {
                currentTimeToDestroy += Time.deltaTime;

                if (currentTimeToDestroy >= timeToDestroy)
                {
                    Debug.Log("averga");
                    cutsceneTrigger.gameObject.SetActive(true);
                }
            }
        }
    }
}
