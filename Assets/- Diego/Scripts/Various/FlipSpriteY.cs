using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private GameObject target = null;

    private void Update()
    {
        if (transform.position.y < target.transform.position.y) // Chequeamos si nuestra posicion en Eje X es MENOR que la del Player
            spriteRenderer.flipX = true; // Volteamos
        else // Si no es MENOR
            spriteRenderer.flipX = false; // No volteamos
    }
}
