using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class ResizeByStoneHealth : MonoBehaviour
    {
        private StoneHealth health = null;

        private void Awake()
        {
            health = GetComponent<StoneHealth>();
        }

        public void Resize()
        {
            transform.localScale *= (health.GetCurrentHealth() / health.GetMaxHealth());
        }
    }
}
