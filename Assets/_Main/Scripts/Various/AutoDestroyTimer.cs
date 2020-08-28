/*
 * Este contador cuenta desde timeToDestroy hasta 0 y una vez que termina destruye el Objeto.
 * 
 * Si queremos detener el contador, hay que desactivar el Objeto.
 * 
 * Si queremos resetearlo para que empiece a contar de nuevo, se usa el ResetTimer.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class AutoDestroyTimer : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy = 600; // Variable donde asignamos el tiempo a contar
        private float timer; // Variable que usamos para llevar la cuenta

        private void Start()
        {
            timer = timeToDestroy; // Inicializamos el timer con el timeToDestroy
        }

        private void Update()
        {
            if (timer > 0) timer -= Time.deltaTime; // Si el timer es mayor a 0 le descontamos Time.deltaTime
            else if (timer <= 0) Destroy(gameObject); // Si es menor o igual a 0 es que termino de contar y destruimos el Objeto
        }

        public void ResetTimer()
        {
            timer = timeToDestroy; // Función de Reset por las dudas de que necesitemos reiniciar el contador
        }
    }
}
