using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WASDtrigger : MonoBehaviour
{
    private float maxTimeOnScreen = 6.0f;
    private float currentTimeOnScreen = 0.0f;

    private bool canCount = false;

    [SerializeField]
    private GameObject firstLight;

    private void Start()
    {
        firstLight.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CutsceneTrigger.isCutsceneOn = true;

            canCount = true;
        }
    }

    private void Update()
    {
        if (canCount)
        {
            Count();
        }

        /*
        if (!canCount && (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {

        }
        */
    }

    void Count()
    {
        currentTimeOnScreen += Time.deltaTime;

        if (currentTimeOnScreen >= maxTimeOnScreen)
        {
            CutsceneTrigger.isCutsceneOn = false;
        }
    }
}
