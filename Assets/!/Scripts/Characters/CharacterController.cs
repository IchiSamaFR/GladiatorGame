using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gladiator.Character
{
    public class CharacterController : MonoBehaviour
    {
        private bool canAttack;

        public void Attack(Character cible)
        {
            if (canAttack)
            {
                if (isInRange(cible) && cible.CharacterStats.isAlive())
                {
                    cible.CharacterStats.GetDamage(1);
                }
            }

        }

        public bool isInRange(Character cible)
        {
            return Vector3.Distance(transform.position, cible.transform.position) <= 1;
        }

    }
}