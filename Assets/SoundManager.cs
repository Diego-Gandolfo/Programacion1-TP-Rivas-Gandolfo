using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Footsteps4;

    private static AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Footsteps4 = Resources.Load<AudioClip>("Footsteps4");
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Footsteps4":
                _audioSource.PlayOneShot(Footsteps4);
                break;
        }
    }
}
