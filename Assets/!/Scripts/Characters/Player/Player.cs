using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerStats))]
    public class Player : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private PlayerStats playerStats;

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
    }
}