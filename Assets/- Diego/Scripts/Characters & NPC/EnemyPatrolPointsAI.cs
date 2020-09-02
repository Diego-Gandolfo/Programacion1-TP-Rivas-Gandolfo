using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Diego
{
    public class EnemyPatrolPointsAI : MonoBehaviour
    {
        [SerializeField] private PatrolPoints patrolPoints = null;
        [SerializeField] private FollowEnemy followEnemy = null;
        private DetectTargetArea detectTargetArea = null;
        [SerializeField] bool keepFollowing = false;

        private void Start()
        {
            detectTargetArea = GetComponent<DetectTargetArea>();
            patrolPoints.enabled = true;
            followEnemy.enabled = false;
        }

        private void Update()
        {
            bool check = detectTargetArea.DetectTargets();

            if (check)
            {
                patrolPoints.enabled = false;
                followEnemy.enabled = true;
            }
            else if (!check && !keepFollowing)
            {
                followEnemy.enabled = false;
                patrolPoints.enabled = true;
            }
        }
    }
}
