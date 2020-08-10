using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterMovement : MonoBehaviour
{
    public float speed;
    public Camera mainCam;
    
    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;

        if (Input.GetKey(KeyCode.S))
            direction -= Vector3.up;

        if (Input.GetKey(KeyCode.A))
            direction -= Vector3.right;

        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        //PARA QUE NO SE COMPENSEN LAS VELOCIDADES CUANDO TOCAS POR EJEMPLO A Y W
        transform.position += direction * speed * Time.deltaTime;

        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - this.transform.position;
        float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
