using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour
{
    [SerializeField]
    private BlockDoorKey key;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !key.hasBlockKey)
        {
            Debug.Log("you cannot pass");
        }
        else if (collision.gameObject.CompareTag("Player") && key.hasBlockKey)
        {
            Debug.Log("now you can");
        }
    }
}
