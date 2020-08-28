using System.Collections;
using System.Collections.Generic;
using OnceUponAMemory.Main;
using Unity.Mathematics;
using UnityEngine;

namespace OnceUponAMemory.Franco
{
    public class RotationController : MonoBehaviour
    {
        public Transform player;

        public float speed = 5f;
        // Update is called once per frame
        void Update()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(player.position) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }

}

