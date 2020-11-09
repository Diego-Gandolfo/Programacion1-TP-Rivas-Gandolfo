using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class GrenadeInput : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string inputCode = "";
        [SerializeField] private int initialGrenades = 0;
        [SerializeField] private int maxGrenades = 0;
        private int currentGrenades = 0;

        [Header("Prefab")]
        [SerializeField] private GrenadeBehavior grenadePrefab = null;
        [SerializeField] private Transform spawnpointPosition = null;

        [Header("Impulse")]
        [SerializeField] private float impulseInitial = 0f;
        [SerializeField] private float impulseIncrement = 0f;
        [SerializeField] private float impulseMax = 0f;
        private float impulseCurrent = 0f;

        [Header("Canvas")]
        [SerializeField] private Text textGranadeAmount = null;

        [SerializeField] private Animator animator;

        private void Awake()
        {
            if (impulseMax < impulseInitial)
            {
                Debug.LogError($"El Impuslo Máximo de {this} es menor al Impuslo Inicial, así que se le asignara el valor de Impulso Inicial");
                impulseMax = impulseInitial;
            }
        }

        private void Start()
        {
            if (initialGrenades > maxGrenades)
                Debug.LogError($"El valor de initialGrenades({initialGrenades}) es mayor a maxGrenades({maxGrenades})");

            currentGrenades = initialGrenades;

            if (textGranadeAmount != null) textGranadeAmount.text = $"{currentGrenades} <b>/</b> {maxGrenades}";
        }

        private void Update()
        {
            if (currentGrenades > 0)
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

                    currentGrenades--;
                    if (textGranadeAmount != null) textGranadeAmount.text = $"{currentGrenades} <b>/</b> {maxGrenades}";

                    SoundManager.PlaySound("Whoosh");
                }
            }

            else if (Input.GetKeyDown(KeyCode.G) && currentGrenades <= 0)
                animator.SetTrigger("Empty");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Grenade") && currentGrenades < maxGrenades)
            {
                currentGrenades++;
                if (textGranadeAmount != null) textGranadeAmount.text = $"{currentGrenades} <b>/</b> {maxGrenades}";

                SoundManager.PlaySound("PickUp");

                Destroy(collision.gameObject);
            }
        }
    }
}
