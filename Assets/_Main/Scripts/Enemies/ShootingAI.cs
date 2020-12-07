using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class ShootingAI : MonoBehaviour
    {
        [SerializeField] private float maxDistanceRange = 0;

        private float timeBetweenShots;
        public float starTimeBetweentShots;

        public Transform firePoint;
        public Transform player;
        public GameObject projectile;

        public Animator animator;

        void Start()
        {
            timeBetweenShots = starTimeBetweentShots;
        }

        void Update()
        {
            //transform.LookAt(player);
            if ((timeBetweenShots <= 0) && (Vector2.Distance(transform.position, player.position) <= maxDistanceRange))
            {
                GameObject projectileClone = Instantiate(projectile, firePoint.position, Quaternion.identity);
                ProjectileScript projectileScript = projectileClone.GetComponent<ProjectileScript>();
                projectileScript.ThrowProjectile(player);

                timeBetweenShots = starTimeBetweentShots;

                animator.SetTrigger("Attack");
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
