﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement_vDiego : MonoBehaviour
{
    public float speed;
    public int health = 10;
    public Animator animator;
    public ParticleSystem blood;



    private void Start()
    {
    }
    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
            animator.SetBool("RunUp", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= Vector3.up;
            animator.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            direction -= Vector3.right;
            animator.SetBool("RunLeft", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            animator.SetBool("RunRight", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
            

        //PARA QUE VUELVA A ESTADO IDLE!
        if (Input.GetKeyUp(KeyCode.S)) animator.SetBool("Run", false);
        if (Input.GetKeyUp(KeyCode.A)) animator.SetBool("RunLeft", false);
        if (Input.GetKeyUp(KeyCode.D)) animator.SetBool("RunRight", false);
        if (Input.GetKeyUp(KeyCode.W)) animator.SetBool("RunUp", false);
     
        /*animator.SetFloat("Back", direction.x);
        animator.SetFloat("Front", direction.y);
        animator.SetFloat("Speed", direction.magnitude);
        */
        transform.position += direction * speed * Time.deltaTime; // PARA QUE NO SE COMPENSEN LAS VELOCIDADES CUANDO TOCAS POR EJEMPLO A Y W




        /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // En lugar de tener una Variable mainCamera se puede usar directamente Camera.main
        Vector3 difference = mousePosition - this.transform.position;

        float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -angle);
        */
    }

    /*public void TakeEnemyDamage(int damage)
    {
        Instantiate(blood, transform.position, Quaternion.identity);


        health -= damage;

        if (health <= 0)
            Die();
        
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }*/
    
}
