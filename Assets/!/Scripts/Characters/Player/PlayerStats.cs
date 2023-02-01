using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Player
{
    public class PlayerStats : CharacterStats
    {
        private Player player;

        public Player Player
        {
            get
            {
                if (!player)
                {
                    player = GetComponent<Player>();
                }
                return player;
            }
        }
    }
}