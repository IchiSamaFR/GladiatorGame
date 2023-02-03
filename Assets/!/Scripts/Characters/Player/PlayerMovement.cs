using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character.Player
{
    public class PlayerMovement : CharacterMovement
    {
        public Transform Transform;
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
            print(AngleBetweenVector2(transform.position, Transform.position));
            Movement();
        }
        private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
        {
            Vector2 diference = vec2 - vec1;
            float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
            return Vector2.Angle(Vector2.right, diference) * sign;
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

            if (Input.GetKey(KeyCode.Space))
            {
                Player.PlayerStats.IsDashing = true;
                Dash(direction, Player.PlayerStats.DashRange, 0.1f, () => Player.PlayerStats.IsDashing = false);
            }
            MoveDirection(direction, Player.PlayerStats.MoveSpeed);
        }
    }
}
