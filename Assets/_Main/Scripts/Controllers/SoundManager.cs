using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class SoundManager : MonoBehaviour
    {

        public static AudioClip NotificationSound, MetalTrap, Empty, IronGateClosed, IronGate, KeyPickUp, Whoosh, PickUp, ShortExplosion, Upbeat, CrateDamage, BreakCrate, GhostDamage, SpiderDie, AttackSound, PickUpItem, EnemyHitRebuild, Dash, SpiderPatrol, PlayerTakeDamage, SpiderDamage, PickUpItemHeal;

        private static AudioSource _audioSource;

        void Start()
        {
            NotificationSound = Resources.Load<AudioClip>("NotificationSound");
            MetalTrap = Resources.Load<AudioClip>("MetalTrap");
            Empty = Resources.Load<AudioClip>("Empty");
            IronGateClosed = Resources.Load<AudioClip>("IronGateClosed");
            IronGate = Resources.Load<AudioClip>("IronGate");
            KeyPickUp = Resources.Load<AudioClip>("KeyPickUp");
            Whoosh = Resources.Load<AudioClip>("Whoosh");
            PickUp = Resources.Load<AudioClip>("PickUp");
            ShortExplosion = Resources.Load<AudioClip>("ShortExplosion");
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
            Upbeat = Resources.Load<AudioClip>("Upbeat");
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
                /*
                case "NotificationSound":
                    _audioSource.PlayOneShot(NotificationSound);
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
                case "Upbeat":
                    _audioSource.PlayOneShot(Upbeat);
                    break;
                case "ShortExplosion":
                    _audioSource.PlayOneShot(ShortExplosion);
                    break;
                case "PickUp":
                    _audioSource.PlayOneShot(PickUp);
                    break;
                case "Whoosh":
                    _audioSource.PlayOneShot(Whoosh);
                    break;
                case "KeyPickUp":
                    _audioSource.PlayOneShot(KeyPickUp);
                    break;
                case "IronGate":
                    _audioSource.PlayOneShot(IronGate);
                    break;
                case "IronGateClosed":
                    _audioSource.PlayOneShot(IronGateClosed);
                    break;
                case "Empty":
                    _audioSource.PlayOneShot(Empty);
                    break;
                case "MetalTrap":
                    _audioSource.PlayOneShot(MetalTrap);
                    break;
            }
        }
    }
}
