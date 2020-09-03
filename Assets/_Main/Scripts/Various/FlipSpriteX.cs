using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FlipSpriteX : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private GameObject target = null;

        private void Start()
        {
            if (spriteRenderer == null || target == null) Debug.LogError("A " + gameObject.name + " le faltan agregar asignar cosas en el Componente FlipSpriteX");
        }

        private void Update()
        {
            if (transform.position.x > target.transform.position.x)
            {
                // Chequeamos si nuestra posicion en Eje X es MAYOR que la del Player
                spriteRenderer.flipX = true; // Volteamos
            }
            else 
            {
                spriteRenderer.flipX = false; // No volteamos
            }
            
        }
    }
}
