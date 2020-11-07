using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MovementAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animatorMovement = null; // Almacenamos el Animator que contiene las Animaciones de Movimiento
        private Vector2 mousePosition; // Almacenamos la posicion del Mouse
        private Vector2 positionDifference; // Almacenaremos la diferencia entre la posicion del Mouse y la del Jugador

        private void Update()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Vemos donde está el Mouse y lo almacenamos

            positionDifference.x = mousePosition.x - transform.position.x; // Nos fijamos la diferencia que hay entre el Mouse y el Objeto en el Eje X
            positionDifference.y = mousePosition.y - transform.position.y; // Nos fijamos la diferencia que hay entre el Mouse y el Objeto en el Eje Y

            animatorMovement.SetFloat("Horizontal", positionDifference.x); // Le indicamos al Animator el valor de Horizontal segun la diferencia en el Eje X, para saber si tiene que mirar a Derecha o Izquierda
            animatorMovement.SetFloat("Vertical", positionDifference.y); // Le indicamos al Animator el valor de Vertical segun la diferencia en el Eje Y, para saber si tiene que mirar a Arriba o Abajo

            if (Input.GetKeyDown(KeyCode.P))
            {
                animatorMovement.SetTrigger("Dance");
                SoundManager.PlaySound("Upbeat");
            }
                
        }
    }
}
