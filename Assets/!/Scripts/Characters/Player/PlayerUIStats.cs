using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Gladiator.Character.Player
{
    public class PlayerUIStats : MonoBehaviour
    {
        private PlayerStats _playerStats;
        public void Init(PlayerUI player)
        {
            _playerStats = player.Player.PlayerStats;
            _playerStats.OnStatsChanged.AddListener(ReloadUI);
        }

        public void ReloadUI()
        {

        }
    }
}
