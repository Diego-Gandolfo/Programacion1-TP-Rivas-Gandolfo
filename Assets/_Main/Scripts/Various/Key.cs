using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Key : MonoBehaviour
    {
        private Vector3 rotation = Vector3.zero;

        private void Start()
        {
            rotation = new Vector3(0, 2, 0);
        }

        private void Update()
        {
            transform.Rotate(rotation);
        }
    }
}
