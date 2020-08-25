using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float currentHeatlh;

        public HealthBar healthBar;

        [SerializeField] private string audioDamage; // En el Inspector escribimos el nombre del Archivo, que sería lo que pones entre comillas... Ejemplo, en el SpiderMonster el audio de daño era "SpiderDamage", en el inspector lo escribimos sin comillas

        public Animator animator;

        void Start()
        {
            currentHeatlh = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        public void TakePlayerDamage(float damage)
        {
            currentHeatlh -= damage;
            SoundManager.PlaySound(audioDamage); // Acá reproducimos el sonido que pusimos en el Inspector
            
            animator.SetTrigger("TakeDamage");

            healthBar.SetHealth(currentHeatlh);
            
            if (currentHeatlh <= 0) Die();
        }
        
        
        
        void Die()
        {
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
            //SoundManager.PlaySound("SpiderDie");
        }
    }
}
