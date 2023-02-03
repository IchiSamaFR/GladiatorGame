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
        public void Fill(Player player)
        {
            _player = player;
        }
    }
}
