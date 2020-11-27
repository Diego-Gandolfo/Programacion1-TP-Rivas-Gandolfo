using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnceUponAMemory.Main
{
    public class CharacterGrenade : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string inputCode = "";

        [Header("Prefab")]
        [SerializeField] private GrenadeBehavior grenadePrefab = null;
        [SerializeField] private Transform spawnpointPosition = null;

        [Header("Impulse")]
        [SerializeField] private float impulseInitial = 0f;
        [SerializeField] private float impulseIncrement = 0f;
        [SerializeField] private float impulseMax = 0f;
        private float impulseCurrent = 0f;

        [Header("Cooldown")]
        [SerializeField] private float cooldown = 2.5f;
        [SerializeField] private Image imageUI = null;
        private float cooldownTimer = 0.0f;
        private bool canCount = false;
        private bool canThrow = true;

        [Header("Stamina")]
        [SerializeField] private float staminaCost = 1.0f;
        private PlayerStamina stamina;


        private void Awake()
        {
            if (gameObject.GetComponent<PlayerStamina>() == null) Debug.LogError(gameObject.name + " no tiene componente PlayerStamina");
            if (gameObject.GetComponent<PlayerStamina>() != null) stamina = gameObject.GetComponent<PlayerStamina>();
        }

        private void Update()
        {
            if (!CutsceneTrigger.isCutsceneOn)
            {
                if (Input.GetKeyDown(inputCode.ToLower()) && (canThrow == true) && stamina.ReduceStamina(staminaCost))
                {
                    impulseCurrent = impulseInitial;
                }

                if (Input.GetKey(inputCode.ToLower()) && impulseCurrent > 0)
                {
                    impulseCurrent += impulseIncrement;
                }

                if (Input.GetKeyUp(inputCode.ToLower()) && impulseCurrent > 0)
                {
                    canThrow = false;
                    canCount = true;

                    impulseCurrent = Mathf.Clamp(impulseCurrent, impulseInitial, impulseMax);

                    GrenadeBehavior grenadeClone = Instantiate(grenadePrefab, spawnpointPosition.position, Quaternion.identity);

                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 direction = mousePosition - transform.position;

                    grenadeClone.ThrowGrenade(direction, impulseCurrent);

                    impulseCurrent = 0;

                    SoundManager.PlaySound("Whoosh");
                }

                if ((cooldownTimer <= 0) && (canCount))
                {
                    cooldownTimer = cooldown;
                    canThrow = true;
                    canCount = false;
                }
                else if ((cooldownTimer > 0) && (canCount))
                {
                    cooldownTimer -= Time.deltaTime;
                    imageUI.fillAmount = 1 - (cooldownTimer / cooldown);
                }
            }
        }
    }
}
