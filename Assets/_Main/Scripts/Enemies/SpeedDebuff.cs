using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class SpeedDebuff : MonoBehaviour
    {
        [SerializeField, Range(0,1)] private float speedDebuffPorcentage = 0f;
        private float playerOriginalSpeed = 0f;
        private float playerCurrentSpeed = 0f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CharacterMovement characterMovement = collision.gameObject.GetComponent<CharacterMovement>();
                playerOriginalSpeed = characterMovement.GetOriginalSpeed();
                playerCurrentSpeed = characterMovement.GetCurrentSpeed();
                characterMovement.SetMovementSpeed(playerCurrentSpeed * speedDebuffPorcentage);
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CharacterMovement characterMovement = collision.gameObject.GetComponent<CharacterMovement>();
                characterMovement.SetMovementSpeed(playerOriginalSpeed);
            }
        }
    }
}
