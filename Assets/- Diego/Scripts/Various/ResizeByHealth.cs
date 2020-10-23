using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class ResizeByHealth : MonoBehaviour
    {
        private Health health = null;

        private void Awake()
        {
            health = GetComponent<Health>();
        }

        public void Resize()
        {
            transform.localScale *= (health.GetCurrentHealth() / health.GetMaxHealth());
        }
    }
}
