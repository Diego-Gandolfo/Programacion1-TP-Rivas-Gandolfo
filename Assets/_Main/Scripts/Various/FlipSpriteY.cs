using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FlipSpriteY : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private GameObject target = null;

        private void Start()
        {
            if (spriteRenderer == null || target == null) Debug.LogError("A " + gameObject.name + " le faltan agregar asignar cosas en el Componente FlipSpriteY");
        }

        private void Update()
        {
            if (transform.position.y < target.transform.position.y) // Chequeamos si nuestra posicion en Eje Y es MENOR que la del Player
                spriteRenderer.flipX = true; // Volteamos
            else // Si no es MENOR
                spriteRenderer.flipX = false; // No volteamos
        }
    }
}
