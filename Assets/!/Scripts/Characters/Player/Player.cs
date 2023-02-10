using Gladiator.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerStats))]
    public class Player : Character
    {
        private PlayerMovement playerMovement;
        private PlayerStats playerStats;
        [SerializeField]
        private AttackController attackController;
        public WeaponData weapon;

        public PlayerMovement PlayerMovement
        {
            get
            {
                if (!playerMovement)
                {
                    playerMovement = GetComponent<PlayerMovement>();
                }
                return playerMovement;
            }
        }
        public PlayerStats PlayerStats
        {
            get
            {
                if (!playerStats)
                {
                    playerStats = GetComponent<PlayerStats>();
                }
                return playerStats;
            }
        }

        public AttackController AttackController
        {
            get
            {
                return attackController;
            }
        }

        private void Start()
        {
            AttackController.EquipWeapon(weapon);
        }
    }
}