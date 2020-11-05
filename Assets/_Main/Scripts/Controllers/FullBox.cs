using OnceUponAMemory.Franco;
using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FullBox : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 3.0f;
        [SerializeField] private float currentHealth;

        private Animator animator;

        [SerializeField] private GameObject fragmentoDeMemoria;

        [SerializeField] private GameObject instanciador;

        private BoxCollider2D boxCollider = null;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        void Start()
        {
            currentHealth = maxHealth;
        }


        public void TakePlayerDamage(float damage)
        {
            currentHealth -= damage;
            SoundManager.PlaySound("CrateDamage");

            animator.SetTrigger("Damaged");

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Destroyed");

                Instantiate(fragmentoDeMemoria, instanciador.transform.position, Quaternion.identity);

                SoundManager.PlaySound("BreakCrate");
                //el problema acá es que no podemos destruir ni desactivar el objeto, porque la animación no se completa
                //no tengo idea de como hacer eso!
                if (boxCollider != null) boxCollider.enabled = false;
            }
        }
    }
}