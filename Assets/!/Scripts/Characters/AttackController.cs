using UnityEngine;
using Gladiator.Tools;
using System.Collections.Generic;
using Gladiator.Item;
using System;

namespace Gladiator.Character
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class AttackController : MonoBehaviour
    {
        private CircleCollider2D circleCollider;
        private WeaponData weapon;
        public Action<CharacterStats> OnCharacterEnter;
        
        public CircleCollider2D CircleCollider
        {
            get
            {
                if (!circleCollider)
                {
                    circleCollider = GetComponent<CircleCollider2D>();
                }
                return circleCollider;
            }
        }
        public void EquipWeapon(WeaponData weapon)
        {
            this.weapon = weapon;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var character = collision.gameObject.GetComponent<CharacterStats>();
            if (character)
            {
                OnCharacterEnter?.Invoke(character);
            }
        }

        public List<Character> GetEnemiesInRange(float angle, string tag)
        {
            List<Character> enemiesList = new List<Character>();
            float forward = transform.rotation.eulerAngles.z;
            forward = (forward < -180) ? forward + 360 : forward;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, CircleCollider.radius);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.gameObject.GetComponent<CharacterStats>() && enemy.gameObject.CompareTag(tag) && enemy.gameObject != gameObject)
                {
                    float enemyAngle = Geometry.AngleBetweenVector2(transform.position, enemy.transform.position);
                    enemyAngle = (enemyAngle < -180) ? enemyAngle + 360 : enemyAngle;
                    if (forward - enemyAngle < angle / 2 || forward - enemyAngle > 360 - angle / 2)
                    {
                        enemiesList.Add(enemy.gameObject.GetComponent<Character>());
                    }
                }
            }
            return enemiesList;
        }

        public void AttackEnemies(string tag = "Enemy")
        {
            foreach (Character enemy in GetEnemiesInRange(weapon.Angle, tag))
            {
                enemy.CharacterStats.GetDamage(1);
            }
        }


    }
}
