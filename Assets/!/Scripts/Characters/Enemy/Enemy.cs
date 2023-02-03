using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gladiator.Character.Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyStats))]
    public class Enemy : Character
    {
        private EnemyMovement enemyMovement;
        private EnemyStats enemyStats;

        public EnemyMovement EnemyMovement
        {
            get
            {
                if (!enemyMovement)
                {
                    enemyMovement = GetComponent<EnemyMovement>();
                }
                return enemyMovement;
            }
        }

        public EnemyStats EnemyStats
        {
            get
            {
                if (!enemyStats)
                {
                    enemyStats = GetComponent<EnemyStats>();
                }
                return enemyStats;
            }
        }
    }
}
