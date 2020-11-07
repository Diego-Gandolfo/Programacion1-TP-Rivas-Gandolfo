using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class ResizeByHealth : MonoBehaviour
    {
        [SerializeField] private float minScaleMagnitude = 0f;
        private Health health = null;

        private void Awake()
        {
            health = GetComponent<Health>();
        }

        private void Update()
        {
            if (transform.localScale.magnitude < minScaleMagnitude)
                Destroy(gameObject);
        }

        public void Resize()
        {
            transform.localScale *= (health.GetCurrentHealth() / health.GetMaxHealth());
        }
    }
}
