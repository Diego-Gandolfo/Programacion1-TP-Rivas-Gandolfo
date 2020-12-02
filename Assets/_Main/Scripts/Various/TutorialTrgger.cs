using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrgger : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
