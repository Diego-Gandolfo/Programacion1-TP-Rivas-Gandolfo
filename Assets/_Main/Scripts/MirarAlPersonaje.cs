using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarAlPersonaje : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }
}
