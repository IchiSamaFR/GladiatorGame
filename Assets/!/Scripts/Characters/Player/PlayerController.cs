using Gladiator.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gladiator.Character.Player
{
    public class PlayerController : CharacterController
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
            LookCursor();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Player.AttackController.AttackEnemies();
            }
        }

        public void LookCursor()
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.LookAt(worldPosition);

            Vector3 mouse = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                                mouse.x,
                                                                mouse.y,
                                                               transform.position.y));
            Vector3 forward = mouseWorld - transform.position;

            float angle = Vector2.SignedAngle(Vector2.right, forward);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}