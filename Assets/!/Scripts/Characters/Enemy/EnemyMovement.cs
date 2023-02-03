using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Enemy
{
    public class EnemyMovement : CharacterMovement
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

        private void FixedUpdate()
        {
            Movement();
        }

        public void Movement()
        {
            //coucou je me déplace
        }
    }
}