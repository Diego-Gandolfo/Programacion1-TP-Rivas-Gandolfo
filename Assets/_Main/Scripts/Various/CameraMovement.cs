using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 1f;

    void Update()
    {
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
    }
}
