using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MovementAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animatorMovement = null;
        private Vector2 mousePosition;
        private Vector2 positionDifference; // Almacenaremos la diferencia entre la posicion del Mouse y la del Jugador

        private void Update()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            positionDifference.x = mousePosition.x - transform.position.x;
            positionDifference.y = mousePosition.y - transform.position.y;

            animatorMovement.SetFloat("Horizontal", positionDifference.x);
            animatorMovement.SetFloat("Vertical", positionDifference.y);
        }
    }
}
