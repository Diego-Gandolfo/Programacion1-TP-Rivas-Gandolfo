using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BoxControl : MonoBehaviour
    {
        public GameObject box, memoryFragment;
        public GameObject instanciador;

        // Start is called before the first frame update
        void Start()
        {
            BoxScript.CreateDestroyed += DestroyBox;
        }

        private void DestroyBox()
        {
            Destroy(box);
            Instantiate(memoryFragment, instanciador.transform.position, Quaternion.identity);
        }

        private void OnDestroy()
        {
            BoxScript.CreateDestroyed -= DestroyBox;
        }
    }
}

