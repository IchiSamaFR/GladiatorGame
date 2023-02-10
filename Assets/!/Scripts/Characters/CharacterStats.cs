using System;
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
        [SerializeField] private float baseStamina;
        [SerializeField] private float baseMaxStamina;
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
        private bool canUseStamina = true;
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
        public float Stamina
        {
            get
            {
                return baseStamina;
            }
        }
        public virtual float MaxStamina
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

        public bool CanConsumeStamina(float amount)
        {
            return Stamina >= amount && canUseStamina;
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
        public void GetStamina(float amount)
        {
            baseStamina = Mathf.Min(baseStamina + amount, MaxStamina);
            OnStatsChanged.Invoke();
        }
        public void GetDamage(int amount)
        {
            baseHealth -= amount;
            if (baseHealth < 0)
            {
                baseHealth = 0;
            }
            if (baseHealth == 0)
            {
                OnDeath.Invoke();
            }
            OnStatsChanged.Invoke();
        }
        public void UseStamina(float amount)
        {
            if (!CanConsumeStamina(amount))
            {
                Debug.LogWarning("[UseStamina()] Need to verify CanConsumeStamina() before UseStamina.");
            }
            if (baseStamina < 1)
            {
                canUseStamina = false;
                StartCoroutine(WaitForCoroutine(() =>
                {
                    if (baseStamina > 20)
                    {
                        canUseStamina = true;
                        return true;
                    }
                    return false;
                }));
            }
            baseStamina -= amount;
            OnStatsChanged.Invoke();
        }

        private IEnumerator InvincibleCoroutine(float duration)
        {
            IsInvincible = true;
            yield return new WaitForSeconds(duration);
            IsInvincible = false;
        }

        private IEnumerator WaitForCoroutine(Func<bool> func)
        {
            while (!func())
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

}