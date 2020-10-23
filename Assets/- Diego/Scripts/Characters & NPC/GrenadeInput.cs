using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class GrenadeInput : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private string inputCode = "";

        [Header("Prefab")]
        [SerializeField] private GrenadeBehavior grenadePrefab = null;
        [SerializeField] private Transform spawnpointPosition = null;

        [Header("Impulse")]
        [SerializeField] private float impulseInitial = 0f;
        [SerializeField] private float impulseIncrement = 0f;
        [SerializeField] private float impulseMax = 0f;
        private float impulseCurrent = 0f;

        private void Awake()
        {
            if (impulseMax < impulseInitial)
            {
                Debug.LogError($"El Impuslo Máximo de {this} es menor al Impuslo Inicial, así que se le asignara el valor de Impulso Inicial");
                impulseMax = impulseInitial;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(inputCode.ToLower()))
                impulseCurrent = impulseInitial;
            if (Input.GetKey(inputCode.ToLower()))
                impulseCurrent += impulseIncrement;
            if (Input.GetKeyUp(inputCode.ToLower()))
            {
                impulseCurrent = Mathf.Clamp(impulseCurrent, impulseInitial, impulseMax);

                GrenadeBehavior grenadeClone = Instantiate(grenadePrefab, spawnpointPosition.position, Quaternion.identity);

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - transform.position;

                grenadeClone.ThrowGrenade(direction, impulseCurrent);

                impulseCurrent = 0;
            }
        }
    }
}
