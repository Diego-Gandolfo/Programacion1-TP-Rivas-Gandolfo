using OnceUponAMemory.Diego;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public static bool isCutsceneOn;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject doorLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCutsceneOn = true;

            animator.SetBool("Cutscene", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;

        animator.SetBool("Cutscene", false);

        Destroy(gameObject);
    }
}
