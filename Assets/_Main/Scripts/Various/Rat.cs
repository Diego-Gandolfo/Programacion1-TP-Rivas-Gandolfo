using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Rat : MonoBehaviour
    {
        private float speed = 5.0f;
        private float timeToLive = 5.0f;
        private float currentTimeToLive = 0.0f;

        private void Update()
        {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;

            currentTimeToLive += Time.deltaTime;

            if (currentTimeToLive >= timeToLive)
                Destroy(gameObject);
        }
    }
}
