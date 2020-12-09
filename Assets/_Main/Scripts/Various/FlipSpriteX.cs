using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class FlipSpriteX : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private GameObject target;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (spriteRenderer == null || target == null) Debug.LogError("A " + gameObject.name + " le faltan agregar asignar cosas en el Componente FlipSpriteX");
        }

        private void Update()
        {
            if (spriteRenderer != null && target != null)
            {
                if (transform.position.x > target.transform.position.x)
                {// Chequeamos si nuestra posicion en Eje X es MAYOR que la del Player
                    print("si");
                    spriteRenderer.flipX = true; // Volteamos
                }
                else // Si no es MENOR
                {
                    print("no");
                    spriteRenderer.flipX = false; // No volteamos
                }
            }
        }
    }
}
