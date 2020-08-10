using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyTimer : MonoBehaviour
{
    public float timeToDestroy = 600;

    private float timer;

    private void Start()
    {
        timer = timeToDestroy;
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else if (timer <= 0) Destroy(gameObject);
    }

    public void ResetTimer()
    {
        timer = timeToDestroy;
    }
}
