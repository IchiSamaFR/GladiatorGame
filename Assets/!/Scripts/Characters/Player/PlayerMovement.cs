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


        public void Move(Vector2 direction)
        {
            if (!Player.PlayerStats.CanMove)
            {
                return;
            }
            MoveDirection(direction, Player.PlayerStats.MoveSpeed);
        }
        public void Run(Vector2 direction)
        {
            if (!Player.PlayerStats.CanMove || !Player.PlayerStats.CanConsumeStamina(0.1f))
            {
                return;
            }
            Player.PlayerStats.UseStamina(0.1f);
            MoveDirection(direction, Player.PlayerStats.MoveSpeed * 2);
        }
        public void Dash(Vector2 direction)
        {
            if (!Player.PlayerStats.CanMove || !Player.PlayerStats.CanConsumeStamina(10))
            {
                return;
            }
            Player.PlayerStats.IsDashing = true;
            Dash(direction, Player.PlayerStats.DashRange, 0.2f, () => Player.PlayerStats.IsDashing = false);
            Player.PlayerStats.UseStamina(10);
        }
    }
}
