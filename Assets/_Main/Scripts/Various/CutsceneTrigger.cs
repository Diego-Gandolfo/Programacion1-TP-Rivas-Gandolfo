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
    private GameObject doorLight;

    [SerializeField]
    private Animator deactivatedTrapAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorLight.SetActive(true);

            isCutsceneOn = true;

            animator.SetBool("Cutscene", true);

            deactivatedTrapAnimator.SetBool("Open", true);

            Invoke(nameof(StopCutscene), 3f);

        }
    }

    void StopCutscene()
    {
        doorLight.SetActive(false);

        isCutsceneOn = false;

        animator.SetBool("Cutscene", false);

        deactivatedTrapAnimator.SetBool("Open", false);

        Destroy(gameObject);
    }
}
