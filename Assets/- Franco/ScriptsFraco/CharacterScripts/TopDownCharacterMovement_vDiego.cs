using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement_vDiego : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    public Animator animator;
    public ParticleSystem blood;

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
            SoundManager.PlaySound("AttackSound");
            animator.SetTrigger("Attack");
        }
            

        //PARA QUE VUELVA A ESTADO IDLE!
        if (Input.GetKeyUp(KeyCode.S)) animator.SetBool("Run", false);
        if (Input.GetKeyUp(KeyCode.A)) animator.SetBool("RunLeft", false);
        if (Input.GetKeyUp(KeyCode.D)) animator.SetBool("RunRight", false);
        if (Input.GetKeyUp(KeyCode.W)) animator.SetBool("RunUp", false);
     

        transform.position += direction * (speed * Time.deltaTime); // PARA QUE NO SE COMPENSEN LAS VELOCIDADES CUANDO TOCAS POR EJEMPLO A Y W
    } 
}
