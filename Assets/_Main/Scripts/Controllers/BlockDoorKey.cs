using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoorKey : MonoBehaviour
{
    public bool hasBlockKey;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasBlockKey = true;
            Debug.Log("You deactivated the trap");
            gameObject.SetActive(false);
        }
        else
            hasBlockKey = false;
    }
}
