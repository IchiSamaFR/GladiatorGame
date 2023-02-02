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
        internal bool isInvincible;
        internal bool isDashing;
        internal bool canMove = true;

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
        public virtual bool IsInvincible
        {
            get
            {
                return isInvincible || isDashing;
            }
            set
            {
                isInvincible = value;
            }
        }
        public virtual bool IsDashing
        {
            get
            {
                return isDashing;
            }
            set
            {
                isDashing = value;
            }
        }
        public virtual bool CanMove
        {
            get
            {
                return canMove && !isDashing;
            }
            set
            {
                canMove = value;
            }
        }

        public bool CanConsumeStamina(int amount)
        {
            return Stamina >= amount;
        }


        public void GetHeal(int amount)
        {
            baseHealth += amount;
        }
        public void GetStamina(int amount)
        {
            baseStamina += amount;
        }
        public void GetDamage(int amount)
        {
            baseHealth -= amount;
            if(baseHealth < 0)
            {
                baseHealth = 0;
            }
        }
        public void UseStamina(int amount)
        {
            if (!CanConsumeStamina(amount))
            {
                Debug.LogWarning("[UseStamina()] Need to verify CanConsumeStamina() before UseStamina.");
            }
            baseStamina -= amount;
        }
    }

}