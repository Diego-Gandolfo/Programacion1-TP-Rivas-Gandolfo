using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator animator;
        private Vector2 mousePosition;
        private Vector2 positionDifference; // Almacenaremos la diferencia entre la posicion del Mouse y la del Jugador

        private void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            positionDifference.x = mousePosition.x - transform.position.x;
            positionDifference.y = mousePosition.y - transform.position.y;

            animator.SetFloat("Horizontal", positionDifference.x);
            animator.SetFloat("Vertical", positionDifference.y);
        }
    }
}
