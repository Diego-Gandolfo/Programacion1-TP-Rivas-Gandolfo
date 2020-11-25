using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MusicTrigger : MonoBehaviour
    {
        [SerializeField]
        private GameObject music;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                music.SetActive(true);
        }
    }
}
