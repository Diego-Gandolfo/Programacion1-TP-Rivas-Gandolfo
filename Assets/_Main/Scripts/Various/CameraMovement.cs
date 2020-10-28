using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class CameraMovement : MonoBehaviour
    {
        private float speed = 3f;

        void Update()
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }
    }
}
