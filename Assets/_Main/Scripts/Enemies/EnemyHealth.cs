using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float currentHeatlh;

        [SerializeField] private string audioDamage = ""; // En el Inspector escribimos el nombre del Archivo, que sería lo que pones entre comillas... Ejemplo, en el SpiderMonster el audio de daño era "SpiderDamage", en el inspector lo escribimos sin comillas
        [SerializeField] private string takingDamage = "";

        private ShootingAI shootingAI = null;
        private EnemyMeleeAttack enemyMeleeAttack = null;
        private EnemyPatrolAreaAI enemyPatrolAreaAI = null;
        private EnemyPatrolPointsAI enemyPatrolPointsAI = null;
        private PatrolArea patrolArea = null;
        private PatrolPoints patrolPoints = null;
        private FollowEnemy followEnemy = null;

        [SerializeField] private Animator animator;

        public HealthBar healthBar;

        private bool canCount = false;

        [SerializeField] private float timeToDie = 2.0f;
        private float currentTimeToDie = 0.0f;

        private void Awake()
        {
            shootingAI = GetComponent<ShootingAI>();
            enemyMeleeAttack = GetComponentInChildren<EnemyMeleeAttack>();
            enemyPatrolAreaAI = GetComponent<EnemyPatrolAreaAI>();
            enemyPatrolPointsAI = GetComponent<EnemyPatrolPointsAI>();
            patrolArea = GetComponent<PatrolArea>();
            patrolPoints = GetComponent<PatrolPoints>();
            followEnemy = GetComponent<FollowEnemy>();
        }

        void Start()
        {
            currentHeatlh = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            
            if (canCount)
                currentTimeToDie += Time.deltaTime;
            if (currentTimeToDie >= timeToDie)
                Destroy(gameObject);
                
        }

        public void TakePlayerDamage(float damage)
        {
            currentHeatlh -= damage;

            SoundManager.PlaySound(audioDamage); // Acá reproducimos el sonido que pusimos en el Inspector
            
            animator.SetTrigger(takingDamage);

            healthBar.SetHealth(currentHeatlh);
            
            if (currentHeatlh <= 0)
            {
                Die();

                canCount = true;
            }
                
        }
        
        void Die()
        {
            Debug.Log("from here...");
            animator.SetTrigger("IsDead");
            animator.SetTrigger("Die");
            Debug.Log("...to eternity");

            healthBar.gameObject.SetActive(false);
            //SoundManager.PlaySound("SpiderDie");

            if (shootingAI != null) shootingAI.enabled = false;
            if (enemyMeleeAttack != null) enemyMeleeAttack.enabled = false;
            if (enemyPatrolAreaAI != null) enemyPatrolAreaAI.enabled = false;
            if (enemyPatrolPointsAI != null) enemyPatrolPointsAI.enabled = false;
            if (patrolArea != null) patrolArea.enabled = false;
            if (patrolPoints != null) patrolPoints.enabled = false;
            if (followEnemy != null) followEnemy.enabled = false;
        }
    }
}
