using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopMovement : MonoBehaviour
{
    public float amplitude = 0.02f;

    void Update()
    {
        transform.position += new Vector3(amplitude * Mathf.Sin(1f * Time.time), 0);
    }
}
