using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FlipWeaponX : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        //[SerializeField] private GameObject target = null;
        private float xOriginalPosition = 0f;

        private void Start()
        {
            xOriginalPosition = transform.position.x;
        }

        private void Update()
        {
            if (spriteRenderer.flipX)
            {
                transform.SetPositionAndRotation(new Vector3(-xOriginalPosition, transform.position.y, transform.position.z), transform.rotation);
            }
            else 
            {
                transform.SetPositionAndRotation(new Vector3(xOriginalPosition, transform.position.y, transform.position.z), transform.rotation);
            }

        }
    }
}
