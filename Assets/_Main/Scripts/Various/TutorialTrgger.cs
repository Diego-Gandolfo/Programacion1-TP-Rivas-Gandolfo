﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrgger : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private float timeToGo = 6.5f;

    [SerializeField]
    private float currentTimeToGo = 0.0f;

    private bool canCount = false;

    private void Update()
    {
        if (canCount)
        {
            currentTimeToGo += Time.deltaTime;

            if (currentTimeToGo >= timeToGo)
            {
                text.SetActive(false);

                currentTimeToGo = 0.0f;
                canCount = false;

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);

            canCount = true;
        }

        else
            text.SetActive(false);
    }
}
