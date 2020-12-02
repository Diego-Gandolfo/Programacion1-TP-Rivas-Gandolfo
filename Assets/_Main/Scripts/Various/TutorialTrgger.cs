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
            Debug.Log("LOLARDO PAPA");
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
