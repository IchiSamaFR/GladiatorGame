using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Enemy
{
    public class EnemyStats : CharacterStats
    {
        private Enemy enemy;


        public Enemy Enemy
        {
            get
            {
                if (!enemy)
                {
                    enemy = GetComponent<Enemy>();
                }
                return enemy;
            }
        }

        private void Start()
        {
            OnDeath.AddListener(() => Destroy(gameObject));
        }
    }
}