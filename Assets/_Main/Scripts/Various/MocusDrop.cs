using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MocusDrop : MonoBehaviour
    {
        private float speed = 3.0f;

        private float lifeTime = 5.0f;
        private float currentLifetime = 0.0f;

        void Update()
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;

            currentLifetime += Time.deltaTime;

            if (currentLifetime >= lifeTime)
                Destroy(gameObject);
        }
    }

}