using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character
{
    public abstract class CharacterStats : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] internal int baseHealth;
        [SerializeField] internal int baseMaxHealth;
        [Header("Stamina")]
        [SerializeField] internal int baseStamina;
        [SerializeField] internal int baseMaxStamina;
        [Header("Attack speed")]
        [SerializeField] internal int baseAttackSpeed;
        [Header("Move speed")]
        [SerializeField] internal int baseMoveSpeed;
        [Header("Dash")]
        [SerializeField] internal float baseDashRange;
        [Header("Attack")]
        [SerializeField] internal int baseAttack;
        [Header("Armor")]
        [SerializeField] internal int baseArmor;
        public bool isInvincible;

        public int Health
        {
            get
            {
                return baseHealth;
            }
        }
        public virtual int MaxHealth
        {
            get
            {
                return baseMaxHealth;
            }
        }
        public int Stamina
        {
            get
            {
                return baseStamina;
            }
        }
        public virtual int MaxStamina
        {
            get
            {
                return baseMaxStamina;
            }
        }
        public virtual int AttackSpeed
        {
            get
            {
                return baseAttackSpeed;
            }
        }
        public virtual int MoveSpeed
        {
            get
            {
                return baseMoveSpeed;
            }
        }
        public virtual float DashRange 
        {
            get
            {
                return baseDashRange;
            }
        }
        public virtual int Attack
        {
            get
            {
                return baseAttack;
            }
        }
        public virtual int Armor
        {
            get
            {
                return baseArmor;
            }
        }

        public bool CanConsumeStamina(int amount) {
            return Stamina >= amount;
        }
    }

}