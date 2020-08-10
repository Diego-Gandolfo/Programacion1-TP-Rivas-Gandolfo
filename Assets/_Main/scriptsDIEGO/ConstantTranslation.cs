using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantTranslation : MonoBehaviour
{
    public Vector3 speedTranslation;

    void Update()
    {
        Vector3 translation = speedTranslation * Time.deltaTime;

        transform.Translate(translation);
    }
}
