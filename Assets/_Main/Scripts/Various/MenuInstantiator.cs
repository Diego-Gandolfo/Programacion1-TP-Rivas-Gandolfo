using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MenuInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject rat = null;

        [SerializeField] private float timeToInstantiate = 5.0f;
        [SerializeField] private float currentTimeToInstantiate = 0.0f;

        [SerializeField] private float instantiatorSpeed = 0.0f;

        private void Start()
        {
            currentTimeToInstantiate = timeToInstantiate;
        }

        private void Update()
        {
            transform.position += new Vector3(instantiatorSpeed, 0, 0) * Time.deltaTime;

            currentTimeToInstantiate += Time.deltaTime;

            if (currentTimeToInstantiate >= timeToInstantiate)
            {
                RatInstantiator();
            }
        }

        void RatInstantiator()
        {
            Instantiate(rat, transform.position, Quaternion.identity);

            currentTimeToInstantiate = 0.0f;
        }
    }
}
