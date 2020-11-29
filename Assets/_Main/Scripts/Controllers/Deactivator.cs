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

        [SerializeField]
        private bool canCount = false;

        private float timeToDestroy = 1f;

        [SerializeField]
        private float currentTimeToDestroy;

        private bool isDestroyed = false;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            isDestroyed = false;

            canCount = false;

            hasBlockKey = false;

            currentHealth = maxHealth;
        }

        public void TakePlayerDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Broken");

                hasBlockKey = true;
                canCount = true;
            }

            else
            {
                canCount = false;
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
                    cutsceneTrigger.gameObject.SetActive(true);

                    Destroy(gameObject);
                }
            }
        }
    }
}
