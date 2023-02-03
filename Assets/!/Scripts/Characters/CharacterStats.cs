using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gladiator.Character
{
    public abstract class CharacterStats : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int baseHealth;
        [SerializeField] private int baseMaxHealth;
        [Header("Stamina")]
        [SerializeField] private int baseStamina;
        [SerializeField] private int baseMaxStamina;
        [Header("Attack speed")]
        [SerializeField] private int baseAttackSpeed;
        [Header("Move speed")]
        [SerializeField] private int baseMoveSpeed;
        [Header("Dash")]
        [SerializeField] private float baseDashRange;
        [Header("Attack")]
        [SerializeField] private int baseAttack;
        [Header("Armor")]
        [SerializeField] private int baseArmor;
        private bool isInvincible;
        private bool isDashing;
        private bool canMove = true;

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
        public UnityEvent OnDeath;
        public UnityEvent OnStatsChanged;

        public bool CanConsumeStamina(int amount)
        {
            return Stamina >= amount;
        }

        public bool isAlive()
        {
            return baseHealth > 0;
        }
        
        public void GetHeal(int amount)
        {
            baseHealth += amount;
            OnStatsChanged.Invoke();
        }
        public void GetStamina(int amount)
        {
            baseStamina += amount;
            OnStatsChanged.Invoke();
        }
        public void GetDamage(int amount)
        {
            baseHealth -= amount;
            if(baseHealth < 0)
            {
                baseHealth = 0;
            }
            if(baseHealth == 0)
            {
                OnDeath.Invoke();
            }
            OnStatsChanged.Invoke();
        }
        public void UseStamina(int amount)
        {
            if (!CanConsumeStamina(amount))
            {
                Debug.LogWarning("[UseStamina()] Need to verify CanConsumeStamina() before UseStamina.");
            }
            baseStamina -= amount;
            OnStatsChanged.Invoke();
        }
    }

}