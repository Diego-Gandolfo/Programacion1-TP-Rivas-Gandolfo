﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BoxControl : MonoBehaviour
    {
        [SerializeField] private GameObject box, memoryFragment;
        [SerializeField] private GameObject instanciador;

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

