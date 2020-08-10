using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public Vector3 speedRotation;

    void Update()
    {
        Vector3 rotation = speedRotation * Time.deltaTime;

        transform.Rotate(rotation);
    }
}
