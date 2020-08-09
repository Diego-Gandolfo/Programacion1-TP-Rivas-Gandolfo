using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopMovementVariant : MonoBehaviour
{
    public float amplitude = 0.02f;

    void Update()
    {
        transform.position += new Vector3(amplitude * Mathf.Cos(1f * Time.time), 0);
    }
}
