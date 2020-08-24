using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class EnemySearch : MonoBehaviour
    {
        public float speed = 2f;
        public float stopAt;
        public Transform player;
        public Transform weapon;

        public string tagObject;
        private GameObject objectWithTag;
        void Start()
        {
            objectWithTag = GameObject.FindGameObjectWithTag(tagObject);
        }

        void Update()
        {
            if ((player != null) && (objectWithTag != null)) // Chequeamos que el player y el objectWithTag estén en la Escena para que no tire errores
            {
                if (Vector2.Distance(transform.position, player.position) > stopAt)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
            }

            if ((player != null) && (objectWithTag != null)) // Chequeamos que el player y el objectWithTag estén en la Escena para que no tire errores
            {
                Vector2 direction = new Vector2(objectWithTag.transform.position.x, objectWithTag.transform.position.y - transform.position.y);
                transform.up = -direction;
            }
            else
            {
                transform.up = new Vector2(0,0); // Para que cuando no esté el Player se quede mirando para arriba
            }
        }
    }

}
