using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class GrenadeBehavior : MonoBehaviour
    {
        [SerializeField] private float frictionValue = 0f;
        private Vector2 direction = Vector2.zero;

        private Rigidbody2D rb2D = null;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(rb2D.velocity.magnitude) > 0)
                rb2D.velocity -= direction * frictionValue;
        }

        public void ThrowGrenade(Vector2 dir, float imp)
        {
            direction = dir;
            rb2D.AddForce(dir * imp, ForceMode2D.Impulse);
        }
    }
}
