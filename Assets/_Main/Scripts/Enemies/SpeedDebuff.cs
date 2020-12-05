using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class SpeedDebuff : MonoBehaviour
    {
        [SerializeField, Range(0,1)] private float speedDebuffPorcentage = 0f;
        private float playerOriginalMovementSpeed = 0f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CharacterMovement characterMovement = collision.gameObject.GetComponent<CharacterMovement>();
                playerOriginalMovementSpeed = characterMovement.GetMovementSpeed();
                characterMovement.SetMovementSpeed(playerOriginalMovementSpeed * speedDebuffPorcentage);
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CharacterMovement characterMovement = collision.gameObject.GetComponent<CharacterMovement>();
                characterMovement.SetMovementSpeed(playerOriginalMovementSpeed);
            }
        }
    }
}
