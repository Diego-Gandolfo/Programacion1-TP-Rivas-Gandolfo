﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private DoorScript door;

        private Vector3 rotation;

        private void Start()
        {
            rotation = new Vector3(0, 2, 0);
        }
        private void Update()
        {
            transform.Rotate(rotation);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                door.hasKey = true;

                Debug.Log("now you have a key");
                gameObject.SetActive(false);
            }
        }
    }
}
