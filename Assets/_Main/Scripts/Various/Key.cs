using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorScript door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            door.hasKey = true;

            Debug.Log("now you have a key");
            gameObject.SetActive(false);
        }
    }
}
