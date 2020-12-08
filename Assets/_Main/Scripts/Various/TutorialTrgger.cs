using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrgger : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    [SerializeField]
    private float timeToGo = 6.5f;
    private float currentTimeToGo = 0.0f;

    private bool canCount = false;

    /*
    [SerializeField]
    private GameObject sound;
    */
    [SerializeField]
    private bool hasToHaveHUD = false;

    [SerializeField]
    private GameObject HUD = null;

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

                gameObject.SetActive(false);
                //sound.gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasToHaveHUD)
                HUD.gameObject.SetActive(true);
            

            //sound.SetActive(true);

            text.SetActive(true);

            canCount = true;
        }

        else
        {
            HUD.gameObject.SetActive(false);

            //sound.SetActive(false);

            text.SetActive(false);
        }
    }
}
