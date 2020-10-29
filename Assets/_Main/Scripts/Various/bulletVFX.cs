using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletVFX : MonoBehaviour
{
    private float lifeTime = 0.2f;
    private float currentLifetime = 0.0f;

    void Update()
    {
        currentLifetime += Time.deltaTime;

        if (currentLifetime >= lifeTime)
            Destroy(gameObject);
    }
}
