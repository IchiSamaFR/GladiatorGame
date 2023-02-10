using Gladiator.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Gladiator.Character.Enemy
{
    [RequireComponent(typeof(HumanMovement))]
    [RequireComponent(typeof(HumanStats))]
    public class Human : Enemy
    {
        private HumanMovement humanMovement;
        private HumanStats humanStats;
        public WeaponData weapon;

        public HumanMovement HumanMovement
        {
            get
            {
                if (!humanMovement)
                {
                    humanMovement = GetComponent<HumanMovement>();
                }
                return humanMovement;
            }
        }

        public HumanStats HumanStats
        {
            get
            {
                if (!humanStats)
                {
                    humanStats = GetComponent<HumanStats>();
                }
                return humanStats;
            }
        }
        
        private void Start()
        {
            AttackController.EquipWeapon(weapon);
        }
    }
}