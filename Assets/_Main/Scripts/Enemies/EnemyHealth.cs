using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float currentHeatlh;

        [SerializeField] private string audioDamage = ""; // En el Inspector escribimos el nombre del Archivo, que sería lo que pones entre comillas... Ejemplo, en el SpiderMonster el audio de daño era "SpiderDamage", en el inspector lo escribimos sin comillas
        [SerializeField] private string takingDamage = "";
        
        public Animator animator;

        public HealthBar healthBar;

        /*
        private bool canCount = false;

        private float timeToDie = 1.0f;
        private float currentTimeToDie = 0.0f;
        */
        void Start()
        {
            currentHeatlh = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            /*
            if (canCount)
                currentTimeToDie += Time.deltaTime;
            if (currentTimeToDie >= timeToDie)
                Destroy(gameObject);
                */
        }

        public void TakePlayerDamage(float damage)
        {
            currentHeatlh -= damage;
            SoundManager.PlaySound(audioDamage); // Acá reproducimos el sonido que pusimos en el Inspector
            
            //animator.SetTrigger(takingDamage);
            animator.SetTrigger("TakeDamage");

            healthBar.SetHealth(currentHeatlh);
            
            if (currentHeatlh <= 0)
            {
                Die();

                //canCount = true;
            }
                
        }
        
        void Die()
        {
            //animator.SetTrigger("IsDead");
            
            healthBar.gameObject.SetActive(false);
            //SoundManager.PlaySound("SpiderDie");
        }
    }
}
