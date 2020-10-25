using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class SoundManager : MonoBehaviour
    {

        public static AudioClip CrateDamage, BreakCrate, GhostDamage, SpiderDie, AttackSound, PickUpItem, EnemyHitRebuild, Dash, SpiderPatrol, PlayerTakeDamage, SpiderDamage, PickUpItemHeal;

        private static AudioSource _audioSource;

        void Start()
        {
            CrateDamage = Resources.Load<AudioClip>("CrateDamage");
            BreakCrate = Resources.Load<AudioClip>("BreakCrate");
            GhostDamage = Resources.Load<AudioClip>("GhostDamage");
            SpiderDie = Resources.Load<AudioClip>("SpiderDie");
            SpiderDamage = Resources.Load<AudioClip>("SpiderDamage");
            PlayerTakeDamage = Resources.Load<AudioClip>("PlayerTakeDamage");
            SpiderPatrol = Resources.Load<AudioClip>("SpiderPatrol");
            Dash = Resources.Load<AudioClip>("Dash");
            EnemyHitRebuild = Resources.Load<AudioClip>("EnemyHitRebuild");
            AttackSound = Resources.Load<AudioClip>("AttackSound");
            PickUpItem = Resources.Load<AudioClip>("PickUpItem");
            PickUpItemHeal = Resources.Load<AudioClip>("PickUpItemHeal");

            _audioSource = GetComponent<AudioSource>();
        }

        public static void PlaySound(string clip)
        {
            switch (clip)
            {
                /*
                case "Footsteps4":
                    _audioSource.PlayOneShot(Footsteps4);
                    break;
                */
                case "GhostDamage":
                    _audioSource.PlayOneShot(GhostDamage);
                    break;
                    
                case "PickUpItem":
                    _audioSource.PlayOneShot(PickUpItem);
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
                case "SpiderDamage":
                    _audioSource.PlayOneShot(SpiderDamage);
                    break;
                case "SpiderDie":
                    _audioSource.PlayOneShot(SpiderDie);
                    break;
                case "PickUpItemHeal":
                    _audioSource.PlayOneShot(PickUpItemHeal);
                    break;
                case "BreakCrate":
                    _audioSource.PlayOneShot(BreakCrate);
                    break;
                case "CrateDamage":
                    _audioSource.PlayOneShot(CrateDamage);
                    break;

            }
        }
    }
}
