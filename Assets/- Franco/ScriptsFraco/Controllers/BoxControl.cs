using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class BoxControl : MonoBehaviour
    {
        public GameObject box, memoryFragment;


        // Start is called before the first frame update
        void Start()
        {
            BoxScript.CreateDestroyed += DestroyBox;
        }

        private void DestroyBox()
        {
            Destroy(box);
            Instantiate(memoryFragment, this.transform.position, Quaternion.identity);
        }

        private void OnDestroy()
        {
            BoxScript.CreateDestroyed -= DestroyBox;
        }
    }
}

