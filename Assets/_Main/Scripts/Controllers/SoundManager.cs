using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Footsteps4, AttackSound, ItemPickUp, EnemyHitRebuild, Dash, SpiderPatrol, PlayerTakeDamage;

    private static AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTakeDamage = Resources.Load<AudioClip>("PlayerTakeDamage");
        SpiderPatrol = Resources.Load<AudioClip>("SpiderPatrol");
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
            case "SpiderPatrol":
                _audioSource.PlayOneShot(SpiderPatrol);
                break;
            case "PlayerTakeDamage":
                _audioSource.PlayOneShot(PlayerTakeDamage);
                break;
        }
    }
}
