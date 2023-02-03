using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Player
{
    public class PlayerMovement : CharacterMovement
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


        private void FixedUpdate()
        {
            Movement();
        }

        public void Movement()
        {
            if (!Player.PlayerStats.CanMove)
            {
                return;
            }
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.Z))
            {
                direction += Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction -= Vector3.up;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                direction += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction -= Vector3.left;
            }

            if(Input.GetKey(KeyCode.Space)) 
            {
                Player.PlayerStats.IsDashing = true;
                Dash(direction,Player.PlayerStats.DashRange, 0.1f, () => Player.PlayerStats.IsDashing = false);
            }
            MoveDirection(direction, Player.PlayerStats.MoveSpeed);
        }
    }
}
