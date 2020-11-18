using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class BoxControl : MonoBehaviour
    {
        [SerializeField] private Transform player = null;

        [SerializeField] 
        private GameObject box = null, memoryFragment = null;

        [SerializeField] 
        private GameObject instanciador = null;

        // Start is called before the first frame update
        void Start()
        {
            BoxScript.CreateDestroyed += DestroyBox;
        }

        private void DestroyBox()
        {
            Destroy(box);
            GameObject instance = Instantiate(memoryFragment, instanciador.transform.position, Quaternion.identity);
            ShootingAI shootingAI = instance.GetComponent<ShootingAI>();
            if (shootingAI != null) shootingAI.player = player;
        }

        private void OnDestroy()
        {
            BoxScript.CreateDestroyed -= DestroyBox;
        }
    }
}

