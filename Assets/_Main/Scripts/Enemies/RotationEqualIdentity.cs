using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEqualIdentity : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
