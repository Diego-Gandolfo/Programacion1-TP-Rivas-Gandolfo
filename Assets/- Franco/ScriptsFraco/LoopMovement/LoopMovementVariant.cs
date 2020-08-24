using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class LoopMovementVariant : MonoBehaviour
    {
        public float amplitude = 0.02f;

        void Update()
        {
            transform.position += new Vector3(amplitude * Mathf.Cos(1f * Time.time), 0);
        }
    }
}

