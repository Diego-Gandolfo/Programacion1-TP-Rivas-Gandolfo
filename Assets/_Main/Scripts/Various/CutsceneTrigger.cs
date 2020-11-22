using OnceUponAMemory.Diego;
using OnceUponAMemory.Franco;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public static bool isCutsceneOn;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Animator doorLightAnimator;

    [SerializeField]
    private GameObject music;

    [SerializeField]
    private GameObject doorLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorLight.SetActive(true);

            music.gameObject.SetActive(true);

            isCutsceneOn = true;

            animator.SetBool("Cutscene", true);

            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        doorLight.SetActive(false);

        isCutsceneOn = false;

        animator.SetBool("Cutscene", false);

        Destroy(gameObject);
    }
}
