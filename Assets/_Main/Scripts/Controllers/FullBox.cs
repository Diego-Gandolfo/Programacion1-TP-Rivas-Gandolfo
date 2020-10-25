using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBox : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3.0f;
    [SerializeField] private float currentHealth;

    private Animator animator;

    [SerializeField] private GameObject fragmentoDeMemoria;

    [SerializeField] private GameObject instanciador;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakePlayerDamage(float damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Damaged");

        if(currentHealth <= 0)
        {
            animator.SetTrigger("Destroyed");

            Instantiate(fragmentoDeMemoria, instanciador.transform.position, Quaternion.identity);

            //el problema acá es que no podemos destruir ni desactivar el objeto, porque la animación no se completa
            //no tengo idea de como hacer eso!
        }
    }
}
