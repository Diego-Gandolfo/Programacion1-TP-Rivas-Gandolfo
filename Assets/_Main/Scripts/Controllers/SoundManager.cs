using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Footsteps4, AttackSound, ItemPickUp, EnemyHitRebuild, Dash;

    private static AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Dash = Resources.Load<AudioClip>("Dash");
        EnemyHitRebuild = Resources.Load<AudioClip>("EnemyHitRebuild");
        AttackSound = Resources.Load<AudioClip>("AttackSound");
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            /*case "Footsteps4":
                _audioSource.PlayOneShot(Footsteps4);
                break;
            */
            case "ItemPickUp":
                _audioSource.PlayOneShot(ItemPickUp);
                break;
            
            case "AttackSound":
                _audioSource.PlayOneShot(AttackSound);
                break;
            
            case "EnemyHitRebuild":
                _audioSource.PlayOneShot(EnemyHitRebuild);
                break;
            case "Dash":
                _audioSource.PlayOneShot(Dash);
                break;
        }
    }
}
