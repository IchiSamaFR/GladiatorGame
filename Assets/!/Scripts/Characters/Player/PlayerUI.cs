using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Gladiator.Character.Player
{
    [RequireComponent(typeof(PlayerUIStats))]
    public class PlayerUI : MonoBehaviour
    {
        private Player _player;
        private PlayerUIStats _playerUIStats;

        public Player Player
        {
            get
            {
                return _player;
            }
        }
        public PlayerUIStats PlayerUIStats
        {
            get
            {
                if (!_playerUIStats)
                {
                    _playerUIStats = GetComponent<PlayerUIStats>();
                }
                return _playerUIStats;
            }
        }

        public void Fill(Player player)
        {
            _player = player;
            PlayerUIStats.Init(this);
        }
    }
}
