using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace OnceUponAMemory.Main
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float parallaxEffectMultiplier = 0f;

        private Transform cameraTransform = null;

        private Vector3 lastCameraPosition = Vector3.zero;

        private float width = 0f;

        private SpriteRenderer spriteRenderer = null;

        void Start()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            spriteRenderer = GetComponent<SpriteRenderer>();
            width = spriteRenderer.bounds.size.x;
        }

        private void FixedUpdate()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, 0f, 0f);
            lastCameraPosition = transform.position;

            float distanceWithCamera = cameraTransform.position.x - transform.position.x;

            if (Mathf.Abs(distanceWithCamera) >= width)
            {
                float movement = 0f;

                if (distanceWithCamera > 0)
                {
                    movement = width * 2f;
                }

                else if (distanceWithCamera < 0)
                {
                    movement = width * -2f;
                }

                transform.position += new Vector3(movement, 0f, 0f);
            }
        }
    }
}
